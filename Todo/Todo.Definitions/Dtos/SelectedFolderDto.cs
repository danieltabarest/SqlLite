using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos
{
    public class SelectedFolderDto
    {
        public Course Course
        {
            get;
            private set;
        }

        public Folder Folder
        {
            get;
            private set;
        }

        public SelectedFolderDto(Course course, Folder folder)
        {
            Course = course;
            Folder = folder;
        }
    }
}
