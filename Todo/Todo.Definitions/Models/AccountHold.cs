using System;

namespace NsuGo.Definition.Models
{
    public class AccountHold
    {
        public string HoldType
        {
            get;
            set;
        }

        public string Originator
        {
            get;
            set;
        }

        public string ProcessAffected
        {
            get;
            set;
        }

        public string Reason
        {
            get;
            set;
        }

        public DateTime Start
        {
            get;
            set;
        }

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
        }

        public AccountHold(string holdType, DateTime start, DateTime end, string reason, string affectedProcess)
        {
            HoldType = holdType;
            Reason = reason;
            ProcessAffected = affectedProcess;
            Start = start;
            End = end;
        }

        public string StartDateFormatted
        {
            get 
            {
                return Start.ToFormattedString();
            }
        }
    }
}
