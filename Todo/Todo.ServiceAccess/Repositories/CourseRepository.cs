using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Common.Helpers;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IAPIContext _apiContext;

        public CourseRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Course> GetCourseAsync(string courseId)
        {
            var uri = $"learning/CourseData/course/course/{courseId}?lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get the course with id: {courseId}";

            return (await _apiContext.GetResourcesAsync<Course, CourseDto>(uri, message)).FirstOrDefault();
        }

        public async Task<IEnumerable<Course>> GetCrosslistedCoursesAsync(string groupCrn, string termCode)
        {
            var uri = $"learning/CourseData/coursewizard/term/{termCode}/crosslistedgroup/{groupCrn}";
            var message = $"There was an error while attempting to retrieve the crosslisted courses for the group crn: {groupCrn} and term code: {termCode}";

            return await _apiContext.GetResourcesAsync<Course, CrosslistedCourseDto>(uri, message);
        }

        public async Task<string> GetCourseNameAsync(string courseId)
        {
			var course = await GetCourseAsync(courseId);
			return course.Name;
        }

        public async Task<IEnumerable<Course>> GetCurrentCoursesAsync()
        {
            var uri = $"learning/CourseData/course?currentCourses=true&lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get the current courses.";

            return await _apiContext.GetResourcesAsync<Course, CourseDto>(uri, message);
        }
    }
}