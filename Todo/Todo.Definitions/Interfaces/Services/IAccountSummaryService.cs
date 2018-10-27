using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IAccountSummaryService
    {
        Task<AccountSummary> AccountSummaryAsync();
    }
}
