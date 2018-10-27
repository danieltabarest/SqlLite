using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos
{
    public class SelectedMeetingDto
    {
        public Meeting Meeting
        {
            get;
            private set;
        }

        public string CourseName
        {
            get;
            private set;
        }

        public SelectedMeetingDto(Meeting meeting, string courseName)
        {
            Meeting = meeting;
            CourseName = courseName;
        }
    }
}
