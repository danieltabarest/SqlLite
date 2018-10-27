using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Common.Helpers;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IAPIContext _apiContext;

        public AssignmentRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync(string courseId)
        {
            var uri = $"learning/CourseData/grade/course/{courseId}?lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get assignments for course with course id: {courseId}";

            return await _apiContext.GetResourcesAsync<Assignment, AssignmentDto>(uri, message);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync()
        {
            var uri = $"learning/CourseData/grade?currentCourses=true&lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get all assignments";

            return await _apiContext.GetResourcesAsync<Assignment, AssignmentDto>(uri, message);
        }
    }
}
