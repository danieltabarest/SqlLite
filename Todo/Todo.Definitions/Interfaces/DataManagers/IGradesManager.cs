using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface IGradesManager
    {
        Task<IEnumerable<Grade>> CompletedGradesForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Grade>> PendingGradesForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Grade>> GradesForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Grade>> RecentGradesAsync(bool refresh = false);

        Task<int> RecentGradesCountAsync();

        void MarkAsRead(Grade grade);
    }
}
