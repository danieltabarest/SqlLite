using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IAssignmentRepository : IPersistenceRepository<Assignment>
    {
        IEnumerable<Assignment> GetAllWithCourseId(string courseId);

        IEnumerable<Assignment> GetAll();

        bool HasAssignmentsWithCourseId(string courseId);

        bool IsEmpty();
    }
}
