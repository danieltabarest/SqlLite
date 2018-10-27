using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface IAnnouncementManager
    {
        Task<IEnumerable<Announcement>> AnnouncementsForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Announcement>> SystemAnnouncementsAsync(bool refresh = false);

        Task<IEnumerable<Announcement>> UnReadAnnouncementsForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Announcement>> RecentAnnouncementsAsync(bool refresh = false);

        Task<int> RecentAnnouncementsCountAsync();

        void MarkAsReadAsync(Announcement announcement);
    }
}
