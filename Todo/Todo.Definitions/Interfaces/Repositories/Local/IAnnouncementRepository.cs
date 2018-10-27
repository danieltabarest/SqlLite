using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IAnnouncementRepository : IPersistenceRepository<Announcement>
    {
        IEnumerable<Announcement> GetAllWithCourseId(string courseId);

        IEnumerable<Announcement> GetCourseAnnouncements();

        IEnumerable<Announcement> GetSystemAnnouncements();

        Announcement Get(string id);

        IEnumerable<Announcement> GetAll();

        bool IsEmpty();

        bool HasSystemAnnouncements();

        bool HasAnnouncementsWithCourseId(string courseId);
    }
}
