using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeAccountSummaryRepository : IAccountSummaryRepository
    {
        public async Task<decimal> GetAccountBalanceAsync()
        {
            await Task.Delay(1000);
            return 10.0m;
        }
    }
}
