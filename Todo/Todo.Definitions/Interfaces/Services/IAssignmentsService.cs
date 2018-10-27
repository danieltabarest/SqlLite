using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IAssignmentsService
    {
        Task<IEnumerable<Assignment>> AssignmentsForCourseAsync(Course course);

        Task<IEnumerable<Assignment>> AssignmentsAsync();
    }
}
