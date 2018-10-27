using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;

        public MeetingService(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public async Task<IEnumerable<RecordedMeeting>> RecordedMeetingsForCourseAsync(Course course)
        {
            var requestData = BuildMeetingRequest(course);
            return (await _meetingRepository.GetRecordedMeetingsForCourseAsync(requestData)).ToList();
        }

        public async Task<IEnumerable<UpcomingMeeting>> UpcomingMeetingsForCourseAsync(Course course)
        {
            var requestData = BuildMeetingRequest(course);
            return (await _meetingRepository.GetUpcomingMeetingsForCourseAsync(requestData)).ToList();
        }

        private IEnumerable<string> RetrieveEmailAddresses(IEnumerable<Staff> staff)
        {
            return staff.Select(s => s.EmailAddress).ToList();
        }

        private MeetingRequestDto BuildMeetingRequest(Course course)
        {
            return new MeetingRequestDto(course.Id, RetrieveEmailAddresses(course.Instructors));
        }
    }
}
