using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Business.DataManagers.Base;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces.DataManagers;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.Business.DataManagers
{
    public class AccountHoldManager : BaseDataManager, IAccountHoldManager
    {
        private readonly IAccountHoldsService _accountHoldService;
        private readonly IAccountHoldRepository _accountHoldRepository;
        private readonly IConnectivityService _connectivityService;

        public AccountHoldManager(
            IAccountHoldsService accountHoldService, 
            IAccountHoldRepository accountHoldRepository,
            IConnectivityService connectivityService
        )
        {
            _accountHoldService = accountHoldService;
            _accountHoldRepository = accountHoldRepository;
            _connectivityService = connectivityService;

        }

        public async Task<IEnumerable<AccountHold>> AccountHoldsAsync(bool refresh = false)
        {
            if (_accountHoldRepository.IsEmpty() || refresh)
                await UpdateAccountHoldsInLocalStorage();

            return _accountHoldRepository.GetAll();
        }

        private async Task UpdateAccountHoldsInLocalStorage()
        {
            //if (await CannotReachHostAsync(_connectivityService))
            //    throw new ApiHostUnReachableException();

            var accountHolds = await _accountHoldService.AccountHoldsAsync();

            if (!_accountHoldRepository.IsEmpty())
                RemoveAllAccountHoldsFromLocalStorage();
            
            SaveToLocalStorage(accountHolds);
            //OnUpdateCompleted();
        }

        private void SaveToLocalStorage(IEnumerable<AccountHold> accountHolds)
        {
            foreach (var accountHold in accountHolds)
                _accountHoldRepository.Add(accountHold);
        }

        protected override void OnPurgeMessageRecieved()
        {
            RemoveAllAccountHoldsFromLocalStorage();
        }

        private void RemoveAllAccountHoldsFromLocalStorage()
        {
            _accountHoldRepository.RemoveAll();
        }

        protected override void OnUpdateDataMessageRecieved()
        {
            RemoveAllAccountHoldsFromLocalStorage();
        }
    }
}
