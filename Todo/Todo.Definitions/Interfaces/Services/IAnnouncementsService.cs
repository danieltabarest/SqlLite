using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IAnnouncementsService
	{
        Task<IEnumerable<Announcement>> AnnouncementsForCourseAsync(Course course);

        Task<IEnumerable<Announcement>> SystemAnnouncementsAsync();

        Task<IEnumerable<Announcement>> CourseAnnouncementsAsync();
	}
}
