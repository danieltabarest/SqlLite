using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class AccountSummaryService : IAccountSummaryService
    {
        private readonly IAccountSummaryRepository _accountSummaryRepository;

        public AccountSummaryService(IAccountSummaryRepository accountSummaryRepository)
        {
            _accountSummaryRepository = accountSummaryRepository;
        }

        public async Task<AccountSummary> AccountSummaryAsync()
        {
            var accountBalance = await _accountSummaryRepository.GetAccountBalanceAsync();
            return new AccountSummary(accountBalance);
        }
    }
}
