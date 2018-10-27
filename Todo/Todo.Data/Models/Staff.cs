using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Staff")]
    public class Staff : PersistenceEntityBase
    {
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

        [MaxLength(100)]
        public string OfficeAddress
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string OfficeHours
        {
            get;
            set;
        }

        [MaxLength(10)]
        public string Phone
        {
            get;
            set;
        }

        public Staff()
        {
            DidSyncToLocalStorage();
        }
    }
}
