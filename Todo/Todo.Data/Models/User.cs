using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("User")]
    public class User : PersistenceEntityBase
    {
        [NotNull]
        [MaxLength(50)]
        public string Username
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string NsuId
        {
            get;
            set;
        }

        [MaxLength(100)]
        public string Name
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string EmailAddress
        {
            get;
            set;
        }

        public string Photo
        {
            get;
            set;
        }

        public User()
        {
            DidSyncToLocalStorage();
        }
    }
}
