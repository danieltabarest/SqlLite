using System;
using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("AccountHold")]
    public class AccountHold : PersistenceEntityBase
    {
		[MaxLength(10)]
		[NotNull]
		public string UserId
		{
			get;
			set;
		}

        [MaxLength(20)]
        [NotNull]
		public string HoldType
		{
			get;
			set;
		}

        [MaxLength(50)]
		public string Originator
		{
			get;
			set;
		}

        [MaxLength(60)]
        [NotNull]
		public string ProcessAffected
		{
			get;
			set;
		}

        [MaxLength(128)]
        [NotNull]
		public string Reason
		{
			get;
			set;
		}

        [NotNull]
		public DateTime Start
		{
			get;
			set;
		}

        [NotNull]
		public DateTime End
		{
			get;
			set;
		}

		public decimal Amount
		{
			get;
			set;
		}

        public AccountHold()
        {
            DidSyncToLocalStorage();
        }



    }
}
