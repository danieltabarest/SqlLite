using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IGradesService
    {
        Task<IEnumerable<Grade>> GradesForCourseAsync(Course course);

        Task<IEnumerable<Grade>> GradesAsync();
    }
}
