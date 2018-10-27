using System;
using Todo.LocalData.Base;
using NsuGo.Definition.Interfaces.Data;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Announcement")]
    public class Announcement : PersistenceEntityBase, IReadable
    {
		[MaxLength(10)]
		[NotNull]
		public string UserId
		{
			get;
			set;
		}

        [Indexed]
		public string CourseId
		{
			get;
			set;
		}

        [MaxLength(128)]
        [NotNull]
		public string Title
		{
			get;
			set;
		}

        [MaxLength(100)]
		public string Author
		{
			get;
			set;
		}

        [NotNull]
		public DateTime CreationDate
		{
			get;
			set;
		}

        [NotNull]
		public bool IsUnread
		{
			get;
			set;
		}

        [MaxLength(10)]
        [NotNull]
        public string Type
		{
			get;
			set;
		}

        [MaxLength(500)]
        public string Body
        {
            get;
            set;
   
        }

        public DateTime FirstRead
        {
            get;
            set;
        }

        public Announcement()
        {
            DidSyncToLocalStorage();
        }
    }
}
