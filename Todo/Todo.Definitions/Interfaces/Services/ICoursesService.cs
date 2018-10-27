using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface ICoursesService
	{
        Task<IEnumerable<Course>> CoursesAsync();

		Task<Course> CourseAsync(string courseId);
	}
}
