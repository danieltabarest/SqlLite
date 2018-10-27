using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class AccountSummaryMapper : Base.BaseDataMapper, IDataMapper<Definition.Models.AccountSummary, AccountSummary>
    {
        public AccountSummaryMapper(IUserAccountRepository userAccountRepository)
            : base(userAccountRepository)
        {
        }

        public AccountSummary ToData(Definition.Models.AccountSummary domain)
        {
            var userId = GetUserId();

            return new AccountSummary
            {
                UserId = userId,
                Id = userId,
                Balance = domain.Balance
            };
        }

        public Definition.Models.AccountSummary ToDomain(AccountSummary data)
        {
            return new Definition.Models.AccountSummary(data.Balance);
        }
    }
}
