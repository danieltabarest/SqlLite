using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly IAPIContext _apiContext;

        public MeetingRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<RecordedMeeting>> GetRecordedMeetingsForCourseAsync(MeetingRequestDto meetingRequest)
        {
            var uri = $"learning/MeetingData/recording";
            var message = $"There was an error while attempting to retrieve recorded meetings for course with id: {meetingRequest.CourseId}.";

            return await _apiContext.PostAsync<RecordedMeeting, RecordedMeetingDto, MeetingRequestDto>(uri, meetingRequest, message);
        }

        public async Task<IEnumerable<UpcomingMeeting>> GetUpcomingMeetingsForCourseAsync(MeetingRequestDto meetingRequest)
        {
			var uri = $"learning/MeetingData/event";
            var message = $"There was an error while attempting to retrieve upcoming meetings for course with id: {meetingRequest.CourseId}";

            return await _apiContext.PostAsync<UpcomingMeeting, UpcomingMeetingDto, MeetingRequestDto>(uri, meetingRequest, message);
        }
    }
}
