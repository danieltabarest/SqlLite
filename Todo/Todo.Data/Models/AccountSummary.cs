using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("AccountSummary")]
    public class AccountSummary : PersistenceEntityBase
    {
		[MaxLength(10)]
		[NotNull]
		public string UserId
		{
			get;
			set;
		}

        [NotNull]
        public decimal Balance
        {
            get;
            set;
        }

        public AccountSummary()
        {
            DidSyncToLocalStorage();
        }
    }
}
