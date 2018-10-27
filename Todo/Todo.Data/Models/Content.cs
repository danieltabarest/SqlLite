using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Content")]
    public class Content : PersistenceEntityBase
    {
        [MaxLength(10)]
        [NotNull]
        public string UserId
        {
            get;
            set;
        }

		public string ParentId
		{
			get;
			set;
		}

        [NotNull]
        [MaxLength(128)]
		public string Title
		{
			get;
			set;
		}

        [NotNull]
        [MaxLength(10)]
		public string CourseId
		{
			get;
			set;
		}

        [NotNull]
        [MaxLength(10)]
        public string ContentType
        {
            get;
            set;
        }

        public Content()
        {
            DidSyncToLocalStorage();
        }
    }
}
