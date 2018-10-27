using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class AssignmentsService : IAssignmentsService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentsService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Assignment>> AssignmentsForCourseAsync(Course course)
        {
            return (await _assignmentRepository.GetAssignmentsAsync(course.Id)).OrderByDescending(a => a.DueDate);
        }

        public async Task<IEnumerable<Assignment>> AssignmentsAsync()
        {
            return await _assignmentRepository.GetAssignmentsAsync();
        }
    }
}
