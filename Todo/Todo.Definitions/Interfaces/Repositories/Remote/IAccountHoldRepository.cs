using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IAccountHoldRepository
    {
        Task<IEnumerable<AccountHold>> GetAccountHoldsAsync();
    }
}
