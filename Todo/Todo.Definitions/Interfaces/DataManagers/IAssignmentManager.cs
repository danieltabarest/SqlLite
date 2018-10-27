using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface IAssignmentManager
    {
        Task<IEnumerable<Assignment>> AssignmentsDueThisWeekForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Assignment>> AssignmentsDueOneWeekFromNowForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Assignment>> AssignmentsDueTwoWeeksFromNowForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Assignment>> PastAssignmentsForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Assignment>> UpcomingAssignmentsForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Assignment>> AssignmentsForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Assignment>> AssignmentsDueThisWeekAsync(bool grouped, bool refresh = false);

        Task<int> AssignmentsDueThisWeekCountAsync();
    }
}
