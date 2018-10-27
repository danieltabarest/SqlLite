using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IMeetingService
    {
        Task<IEnumerable<RecordedMeeting>> RecordedMeetingsForCourseAsync(Course course);

        Task<IEnumerable<UpcomingMeeting>> UpcomingMeetingsForCourseAsync(Course course);
    }
}
