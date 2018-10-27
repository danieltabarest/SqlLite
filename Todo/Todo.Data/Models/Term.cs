using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Term")]
    public class Term : PersistenceEntityBase
    {
		[MaxLength(6)]
        [NotNull]
        public string Code
        {
            get;
            set;
        }

        [NotNull]
        [MaxLength(20)]
        public string Description
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string Status
        {
            get;
            set;
        }

        public Term()
        {
            DidSyncToLocalStorage();
        }
    }
}
