using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface ITermBalancesService
    {
        Task<TermBalance> CurrentTermBalanceAsync();

        Task<TermBalance> TermBalanceAsync(Term term);
    }
}
