using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos
{
    public class SelectedVideoDto
    {
	
        public Video Video
        {
            get;
            set;
        }

        public string CourseName
        {
            get;
            set;
        }

        public SelectedVideoDto(Video video, string courseName)
        {
            Video = video;
            CourseName = courseName;
        }
    }
}
