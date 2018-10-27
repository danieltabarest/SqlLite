using System;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Utilities;

namespace NsuGo.Definition.Models
{
    public class Folder : Content
    {
        public FolderType Type
        {
            get;
            set;
        }

        public int? ItemCount
        {
            get;
            set;
        }

        public ApplicationType ApplicationType
        {
            get;
            set;
        }

        public Folder()
        {
        }

        public Folder(string id, string title, string courseId, FolderType type = FolderType.General)
        {
            Id = id;
            Title = title;
            CourseId = courseId;
            Type = type;
            ApplicationType = ApplicationType.None;
        }

		public string ItemCountDisplay
		{
			get
			{
				return Convert.ToString(ItemCount);
			}
		}

        public override string DisplayIcon {
            get 
            {
                if (Type == FolderType.VideoPlaylist)
                    return CellIcon.VideoPlaylistIcon;
                    
                return CellIcon.FolderIcon;
            }
        }
    }
}
