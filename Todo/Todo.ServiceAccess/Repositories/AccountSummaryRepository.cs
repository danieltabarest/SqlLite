using System;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;

namespace NsuGo.ServiceAccess.Repositories
{
    public class AccountSummaryRepository : IAccountSummaryRepository
    {
        private readonly IAPIContext _apiContext;

        public AccountSummaryRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<decimal> GetAccountBalanceAsync()
        {
            var uri = $"learning/AccountData/user/accountsummary";
            var message = $"There was an error while attempting to get the account summary";

            var accountBalance = await _apiContext.GetResourceAsync<string, AccountSummaryDto>(uri, message);

            return Convert.ToDecimal(accountBalance);
        }
    }
}
