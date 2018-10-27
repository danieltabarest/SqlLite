using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class AccountHoldRepository : IAccountHoldRepository
    {
        private readonly IAPIContext _apiContext;

        public AccountHoldRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<AccountHold>> GetAccountHoldsAsync()
        {
            var uri = $"learning/AccountData/user/accounthold";
            var message = $"There was an error while attempting to get the account holds";

            return await _apiContext.GetResourcesAsync<AccountHold, AccountHoldDto>(uri, message);
        }
    }
}
