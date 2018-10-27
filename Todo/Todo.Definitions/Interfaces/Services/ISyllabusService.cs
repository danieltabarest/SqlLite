using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface ISyllabusService
    {
        Task<IEnumerable<Syllabus>> SyllabiForCourseAsync(Course course);
    }
}
