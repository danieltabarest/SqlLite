using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Folder")]
    public class Folder : PersistenceEntityBase
    {
        
        [MaxLength(20)]
        [NotNull]
        public string FolderType
		{
			get;
			set;
		}

		public int ItemCount
		{
			get;
			set;
		}

        [MaxLength(20)]
        [NotNull]
        public string ApplicationType
		{
			get;
			set;
		}

        public Folder()
        {
            DidSyncToLocalStorage();
        }
    }
}
