using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Common.Helpers;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly IAPIContext _apiContext;

        public AnnouncementRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
        {
			var uri = $"learning/CourseData/announcement?lms={Preferences.LMS}";
			var message = $"There was an error while attempting to get all announcements";

			return await _apiContext.GetResourcesAsync<Announcement, AnnouncementDto>(uri, message);
        }

        public async Task<IEnumerable<Announcement>> GetCourseAnnouncementsAsync(string courseId)
        {
            var uri = $"learning/CourseData/announcement/course/{courseId}?lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get the course announcements for course id {courseId}";

            return await _apiContext.GetResourcesAsync<Announcement, AnnouncementDto>(uri, message);
        }

        public async Task<IEnumerable<Announcement>> GetCourseAnnouncementsAsync()
        {
            var uri = $"learning/CourseData/announcement?currentCourses=true&lms={Preferences.LMS}";
            var message = $"There was an error while attempting to get all course announcements for the current courses.";

            return await _apiContext.GetResourcesAsync<Announcement, AnnouncementDto>(uri, message);
        }

        public async Task<IEnumerable<Announcement>> GetSystemAnnouncementsAsync()
        {
            var uri = "learning/CourseData/announcement/system";
            var message = $"There was an error while attempting to get the system announcements";

            return await _apiContext.GetResourcesAsync<Announcement, AnnouncementDto>(uri, message);
        }
    }
}
