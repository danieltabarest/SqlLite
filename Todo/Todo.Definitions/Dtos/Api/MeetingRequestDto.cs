using System.Collections.Generic;

namespace NsuGo.Definition.Dtos.Api
{
    public class MeetingRequestDto
    {
        public string CourseId
        {
            get;
            set;
        }

        public IEnumerable<string> StaffEmailAddress
        {
            get;
            set;
        }

        public MeetingRequestDto(string courseId, IEnumerable<string> emailAddresses)
        {
            CourseId = courseId;
            StaffEmailAddress = emailAddresses;
        }
    }
}
