using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class AnnouncementService : IAnnouncementsService
	{
		private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository)
		{
            _announcementRepository = announcementRepository;
		}

        public async Task<IEnumerable<Announcement>> AnnouncementsForCourseAsync(Course course)
        {
            return (await _announcementRepository.GetCourseAnnouncementsAsync(course.Id))
                .OrderByDescending(a => a.CreationDate)
                .ToList();
        }

        public async Task<IEnumerable<Announcement>> SystemAnnouncementsAsync()
        {
            return (await _announcementRepository.GetSystemAnnouncementsAsync())
                .OrderByDescending(a => a.CreationDate)
                .ToList();
        }

        public async Task<IEnumerable<Announcement>> CourseAnnouncementsAsync()
        {
            return (await _announcementRepository.GetCourseAnnouncementsAsync())
                .OrderByDescending(a => a.CreationDate)
                .ToList();
        }
    }
}
