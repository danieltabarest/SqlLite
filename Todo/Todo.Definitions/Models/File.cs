using System.Linq;
using Todo.Common.Helpers;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Utilities;

namespace NsuGo.Definition.Models
{
    public class File : Content
    {
        public FileType Type
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }   

        public string Body
        {
            get;
            set;
        }

        public string Filename
        {
            get;
            set;
        }

        public string Extension
        {
            get;
            set;
        }

        public double SizeInBytes
        {
            get;
            set;
        }

        public File()
        {
        }

        public File(string id, string title, string courseId, FileType type)
        {
            Id = id;
            Title = title;
            CourseId = courseId;
            Type = type;
        }

        public override string DisplayIcon 
        {
            get
            {
                string displayIcon;

                if(Type == FileType.Document || Type == FileType.File)
                {
                    var extension = Extension?.ToLower() ?? string.Empty;

                    if (Preferences.PortableFileDocumentExtensions.Contains(extension))
                        displayIcon = CellIcon.PDFDocumentIcon;
                    
                    else if (Preferences.SpreadsheetExtensions.Contains(extension))
                        displayIcon = CellIcon.SpreadsheetIcon;
                    
                    else if (Preferences.WordDocumentExtentions.Contains(extension))
                        displayIcon = CellIcon.WordDocumentIcon;
                    
                    else if (Preferences.PresentationDocumentExtensions.Contains(extension))
                        displayIcon = CellIcon.PresentationIcon;
                    
                    else if (Preferences.ImageDocumentExtensions.Contains(extension))
                        displayIcon = CellIcon.ImageIcon;
                    
                    else
                        displayIcon = CellIcon.DocumentIcon;
                }
                else if (Type == FileType.Video)
                {
                    displayIcon = CellIcon.VideoIcon;    
                }
                else
                {
                    displayIcon = CellIcon.LinkIcon;    
                }

                return displayIcon;
            }
        }

    }
}
