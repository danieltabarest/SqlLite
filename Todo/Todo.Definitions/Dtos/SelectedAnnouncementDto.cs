using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos
{
    public class SelectedAnnouncementDto
    {
        public Announcement Announcement
        {
            get;
            set;
        }

        public string CourseName
        {
            get;
            set;
        }
    }
}
