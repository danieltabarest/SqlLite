using System.Collections.Generic;

namespace NsuGo.Definition.Models
{
    public class TermBalance
    {
        public Term Term
        {
            get;
            private set;
        }

        public decimal Balance
        {
            get;
            private set;
        }

        public decimal Charge
        {
            get;
            private set;
        }

        public decimal Credit
        {
            get;
            private set;
        }

        public IEnumerable<Transaction> Activities
        {
            get;
            set;
        }

        public TermBalance()
        {
        }

        public TermBalance(Term term, decimal balance,  decimal charge, decimal credit)
        {
            Term = term;
            Balance = balance;
            Charge = charge;
            Credit = credit;
            Activities = new List<Transaction>();
        }
    }
}
