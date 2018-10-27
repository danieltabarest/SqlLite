namespace NsuGo.Definition.Models
{
    public class AccountSummary
    {
        public decimal Balance
        {
            get;
            set;
        }

		public AccountSummary()
		{
		}

        public AccountSummary(decimal balance)
        {
            Balance = balance;
        }
    }
}
