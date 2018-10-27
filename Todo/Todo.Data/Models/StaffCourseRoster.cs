using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("StaffCourseRoster")]
    public class StaffCourseRoster : PersistenceEntityBase
    {
        [NotNull]
        [MaxLength(10)]
        public string StaffId
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

        public StaffCourseRoster()
        {
            DidSyncToLocalStorage();
        }
    }
}
