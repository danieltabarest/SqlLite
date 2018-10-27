using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface IAccountHoldManager
    {
        Task<IEnumerable<AccountHold>> AccountHoldsAsync(bool refresh = false);
    }
}
