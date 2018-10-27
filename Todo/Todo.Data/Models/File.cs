using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("File")]
    public class File : PersistenceEntityBase
    {
        
        [MaxLength(30)]
        [NotNull]
        public string FileType
		{
			get;
			set;
		}

        [MaxLength(256)]
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

        [MaxLength(256)]
		public string Filename
		{
			get;
			set;
		}

        [MaxLength(5)]
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
            DidSyncToLocalStorage();
        }
    }
}
