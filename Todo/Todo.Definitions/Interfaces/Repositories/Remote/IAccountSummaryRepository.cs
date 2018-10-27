using System.Threading.Tasks;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IAccountSummaryRepository
    {
        Task<decimal> GetAccountBalanceAsync();
    }
}
