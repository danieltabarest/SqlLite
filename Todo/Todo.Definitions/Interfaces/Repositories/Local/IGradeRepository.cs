using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IGradeRepository : IPersistenceRepository<Grade>
    {
        IEnumerable<Grade> GetAllWithCourseId(string courseId);

        Grade Get(string id);

        IEnumerable<Grade> GetAll();

        bool IsEmpty();

        bool HasGradesForCourseWithId(string courseId);
    }
}
