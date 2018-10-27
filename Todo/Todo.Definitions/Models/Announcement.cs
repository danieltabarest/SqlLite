using System;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Utilities;

namespace NsuGo.Definition.Models
{
    public class Announcement
	{
		public string Id
		{
			get;
			set;
		}

		public string CourseId
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string Author
		{
			get;
			set;
		}

		public DateTime CreationDate
		{
			get;
			set;
		}

		public bool IsUnread
		{
			get;
			set;
		}

        public DateTime FirstRead
        {
            get;
            set;
        }

        public ListGroup Group
        {
            get;
            set;
        }

		public AnnouncementType Type
		{
			get;
			set;
		}

        public Announcement()
        {
        }

        public Announcement(string id, string title, DateTime creationDate, AnnouncementType type)
		{
			Id = id;
			Title = title;
			Type = type;
			CreationDate = creationDate;
		}

		public string CreationDateFormatted
		{
			get
			{
				return CreationDate.ToFormattedString();
			}
		}

		private string _body;
		public string Body
		{
			get
			{
				return _body;
			}

			set
			{
				_body = value.RemoveAllHtml();
			}
		}

        public void MarkAsRead()
        {
            IsUnread = false;
            FirstRead = DateTime.Now;
        }
	}
}
