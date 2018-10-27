using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class CoursesService : ICoursesService
	{
		private readonly ICourseRepository _courseRepository;

		public CoursesService(ICourseRepository courseRepository)
		{
            _courseRepository = courseRepository;
		}

		public async Task<Course> CourseAsync(string courseId)
		{
			return await _courseRepository.GetCourseAsync(courseId);
		}

        public async Task<IEnumerable<Course>> CoursesAsync()
		{
            var courses = await _courseRepository.GetCurrentCoursesAsync();

            courses = await Task.WhenAll(courses.Select(async (Course course) =>
            {
                if (course.IsCrosslisted)
                    course.CrosslistedCrn = await GetCrosslistedCrn(course.CRN, course.Term.Code);

                return course;
            }));

            return courses;
		}

        private async Task<string> GetCrosslistedCrn(string groupCrn, string termCode)
        {
            var crns = new List<string>();

            Course crosslistedCourse = (await _courseRepository.GetCrosslistedCoursesAsync(groupCrn, termCode)).FirstOrDefault();

            if (crosslistedCourse == null)
                return string.Empty;

            return crosslistedCourse.CRN;
        }
    }
}
