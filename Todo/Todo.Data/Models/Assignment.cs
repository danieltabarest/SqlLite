using System;
using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Assignment")]
    public class Assignment : PersistenceEntityBase
    {
		[MaxLength(10)]
		[NotNull]
		public string UserId
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
        [MaxLength(128)]
		public string Name
		{
			get;
			set;
		}

        [NotNull]
		public DateTime DueDate
		{
			get;
			set;
		}

        public Assignment ()
        {
            DidSyncToLocalStorage();
        }
    }
}
