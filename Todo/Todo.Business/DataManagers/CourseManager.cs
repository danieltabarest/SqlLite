using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Business.DataManagers.Base;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces.DataManagers;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;
using NsuGo.Definition.Utilities;
using Todo;

namespace NsuGo.Business.DataManagers
{
    public class CourseManager : BaseDataManager, ICourseManager
    {
        private readonly ICoursesService _courseService;
        private readonly ICourseRepository _courseRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IStaffCourseRosterRepository _staffCourseRepository;
        private readonly ITermManager _termManager;
        private readonly IConnectivityService _connectivityService;
        
        public CourseManager(
            ICoursesService courseService, 
            ICourseRepository courseRepository,
            IStaffRepository staffRepository,
            IStaffCourseRosterRepository staffCourseRepository,
            ITermManager termManager,
            IConnectivityService connectivityService
        )
        {
            _courseService = courseService;
            _courseRepository = courseRepository;
            _termManager = termManager;
            _connectivityService = connectivityService;
            _staffRepository = staffRepository;
            _staffCourseRepository = staffCourseRepository;

            //SubscribeForNotifications(this);
        }

        public async Task<Course> CourseAsync(string courseId)
        {
            if (!_courseRepository.HasCourseWithId(courseId))
                await SyncLocalStorageWithCourse(courseId);

            return GetCourseWithId(courseId);
        }

        private async Task SyncLocalStorageWithCourse(string courseId)
        {
            var course = await _courseService.CourseAsync(courseId);
            SaveCourse(course);
        }

        public async Task<int> CourseCountAsync()
        {
            var courses = await CoursesAsync();
            return courses.Count();
        }

        public async Task<string> CourseNameByIdAsync(string courseId)
        {
            var course = await CourseAsync(courseId);
            return course.Name;
        }

        public async Task<IEnumerable<Course>> CoursesAsync(bool refresh = false)
        {
            if (_courseRepository.IsEmpty() || refresh)
                await UpdateCoursesInLocalStorage();

            return await GetCoursesGroupedByTerm();
        }

        private async Task<IEnumerable<Course>> GetCoursesGroupedByTerm()
        {
            var courses = GetCourses();

            courses = await Task.WhenAll(courses.Select(async c =>
            {
                await AssignTermToCourse(c);
                AssignGroupToCourse(c);

                return c;
            }));

            return courses;
        }

        private async Task UpdateCoursesInLocalStorage()
        {
            if (await CannotReachHostAsync(_connectivityService))
                throw new ApiHostUnReachableException();
            
            await SyncLocalStorageWithCourses();

            OnUpdateCompleted();
        }

        private async Task SyncLocalStorageWithCourses()
        {
            if (!_courseRepository.IsEmpty())
                RemoveAllCoursesFromLocalStorage();
            
            var courses = (await _courseService.CoursesAsync());

            foreach (var course in courses)
                SaveCourse(course);
        }

        protected override void OnPurgeMessageRecieved()
        {
            RemoveAllCoursesFromLocalStorage();
        }

        protected override void OnUpdateDataMessageRecieved()
        {
            RemoveAllCoursesFromLocalStorage();
        }

        private void RemoveAllCoursesFromLocalStorage()
        {
            _courseRepository.RemoveAll();
            _staffRepository.RemoveAll();
            _staffCourseRepository.RemoveAll();
        }

        private async Task AssignTermToCourse(Course course)
        {
            Term term = null;
            //if (course.CourseType == CourseType.AcademicCourse)
                term = await _termManager.TermByCodeAsync(course.Term.Code);

            course.Term = term;
        }

        private void AssignGroupToCourse(Course course)
        {
            if (course.CourseType == CourseType.AcademicCourse && course.Term != null)
                course.Group = new ListGroup(course.Term.Description);

            else if (course.CourseType == CourseType.TrainingCourse)
                course.Group = new ListGroup("Training Courses", 2);

            else
                course.Group = new ListGroup("Other", 3);
        }

        private Course GetCourseWithId(string courseId)
        {
            var course = _courseRepository.Get(courseId);
            AssignInstructorsToCourse(course);

            return course;
        }

        private void AssignInstructorsToCourse(Course course)
        {
            if (_staffCourseRepository.HasStaffForCourse(course))
                course.Instructors = GetInstructorsForCourse(course);
        }

        private IEnumerable<Staff> GetInstructorsForCourse(Course course)
        {
            var instructorIds = _staffCourseRepository.GetStaffIdsForCourse(course);
            var instructors = new List<Staff>();

            foreach (var id in instructorIds)
            {
                var instructor = _staffRepository.Get(id);
                instructors.Add(instructor);
            }

            return instructors;
        }

        private IEnumerable<Course> GetCourses()
        {
            var courses = _courseRepository.GetAll();
            return CoursesWithAssignedInstructors(courses);
        }

        private IEnumerable<Course> CoursesWithAssignedInstructors(IEnumerable<Course> courses)
        {
            courses = courses.Select(course =>
            {
                AssignInstructorsToCourse(course);
                return course;
            });
            return courses;
        }

        private void SaveCourse(Course course)
        {
            _courseRepository.Add(course);
            SaveInstructorsForCourse(course);
        }

        private void SaveInstructorsForCourse(Course course)
        {
            foreach (var instructor in course.Instructors)
            {
                if (IsNewInstructor(instructor))
                    _staffRepository.Add(instructor);

                _staffCourseRepository.Add(instructor, course);
            }
        }

        private bool IsNewInstructor(Staff instructor)
        {
            return (_staffRepository.Get(instructor.Id) == null);
        }

        public Task SaveAsync(TodoItem todoItem)
        {
            //_courseRepository.Add(todoItem);
            return null;
        }
    }
}