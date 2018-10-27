using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface ICourseRepository : IPersistenceRepository<Course>
    {
        Course Get(string id);

        IEnumerable<Course> GetAll();

        bool IsEmpty();

        bool HasCourseWithId(string id);
    }
}
