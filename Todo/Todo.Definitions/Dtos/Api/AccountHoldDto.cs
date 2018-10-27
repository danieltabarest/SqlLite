using System;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class AccountHoldDto : Base.JsonObject<AccountHold>
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

        public string FromDate
        {
            get;
            set;
        }

        public string ToDate
        {
            get;
            set;
        }

        public string Amount
        {
            get;
            set;
        }

        public override AccountHold ToDomainModel()
        {
            return new AccountHold(HoldType, DateTime.Parse(FromDate), DateTime.Parse(ToDate), Reason, ProcessAffected)
            {
                Originator = Originator,
                Amount = Convert.ToDecimal(Amount)
            };
        }

    }
}
