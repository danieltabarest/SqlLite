using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IMeetingRepository
    {
        Task<IEnumerable<RecordedMeeting>> GetRecordedMeetingsForCourseAsync(MeetingRequestDto meetingRequest);

        Task<IEnumerable<UpcomingMeeting>> GetUpcomingMeetingsForCourseAsync(MeetingRequestDto meetingRequest);
	}
}
