using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class AccountHoldMapper : Base.BaseDataMapper, IDataMapper<Definition.Models.AccountHold, AccountHold>
    {
        public AccountHoldMapper(IUserAccountRepository userAccountRepository)
            : base(userAccountRepository)
        {
        }

        public AccountHold ToData(Definition.Models.AccountHold domain)
        {
            var userId = GetUserId();

            return new AccountHold
            {
                Id = $"{domain.HoldType}-{domain.Start}",
                UserId = userId,
                HoldType = domain.HoldType,
                Originator = domain.Originator,
                ProcessAffected = domain.ProcessAffected,
                Reason = domain.Reason,
                Start = domain.Start,
                End = domain.End,
                Amount = domain.Amount
            };
        }

        public Definition.Models.AccountHold ToDomain(AccountHold data)
        {
            return new Definition.Models.AccountHold
			{
				HoldType = data.HoldType,
				Originator = data.Originator,
				ProcessAffected = data.ProcessAffected,
				Reason = data.Reason,
				Start = data.Start,
				End = data.End,
				Amount = data.Amount
			};
        }
    }
}
