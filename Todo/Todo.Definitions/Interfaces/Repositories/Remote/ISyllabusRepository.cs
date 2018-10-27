using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface ISyllabusRepository
    {
        Task<IEnumerable<Syllabus>> GetSyllabiForCourseAsync(string crn, string termCode, bool isCrosslistedCourse);
    }
}
