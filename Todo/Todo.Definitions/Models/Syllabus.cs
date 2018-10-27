using NsuGo.Definition.Enums;

namespace NsuGo.Definition.Models
{
    public class Syllabus : File
    {
        public bool Endorsed
        {
            get;
            set;
        }

        public Syllabus(string id, string title, string url) 
            : base (id, title, string.Empty, FileType.File)
        {
            Url = url;
            Extension = "pdf";
        }
    }
}
