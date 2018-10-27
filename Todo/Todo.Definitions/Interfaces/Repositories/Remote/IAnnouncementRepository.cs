using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IAnnouncementRepository
	{
		Task<IEnumerable<Announcement>> GetCourseAnnouncementsAsync(string courseId);

        Task<IEnumerable<Announcement>> GetCourseAnnouncementsAsync();

		Task<IEnumerable<Announcement>> GetSystemAnnouncementsAsync();

        Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync();
	}
}
