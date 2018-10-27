using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IContentRepository : IPersistenceRepository<Content>
    {
        IEnumerable<Content> GetAllWithCourseId(string courseId);

        bool HasContentWithCourseId(string courseId);
    }
}
