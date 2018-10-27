using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Common.Helpers;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IAPIContext _apiContext;

        public GradeRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync(string courseId)
        {
            var uri = $"learning/CourseData/grade/course/{courseId}?lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get the grades for the course with the id: {courseId}.";

            return await _apiContext.GetResourcesAsync<Grade, GradeDto>(uri, message);
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            var uri = $"learning/CourseData/grade?currentCourses=true&lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get all current grades.";

            return await _apiContext.GetResourcesAsync<Grade, GradeDto>(uri, message);
        }
    }
}
