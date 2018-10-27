using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface ICourseRepository
	{
		Task<IEnumerable<Course>> GetCurrentCoursesAsync();

		Task<Course> GetCourseAsync(string courseId);

        Task<string> GetCourseNameAsync(string courseId);

        Task<IEnumerable<Course>> GetCrosslistedCoursesAsync(string groupCrn, string termCode);
	}
}
