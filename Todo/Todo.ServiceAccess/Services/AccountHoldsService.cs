using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class AccountHoldsService : IAccountHoldsService
    {
        private readonly IAccountHoldRepository _accountHoldRepository;

        public AccountHoldsService(IAccountHoldRepository accountHoldRepository)
        {
            _accountHoldRepository = accountHoldRepository;
        }

        public async Task<IEnumerable<AccountHold>> AccountHoldsAsync()
        {
            return await _accountHoldRepository.GetAccountHoldsAsync();
        }
    }
}
