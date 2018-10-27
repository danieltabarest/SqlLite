using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface IAccountSummaryManager
    {
        Task<AccountSummary> AccountSummaryAsync(bool refresh = false);
    }
}
