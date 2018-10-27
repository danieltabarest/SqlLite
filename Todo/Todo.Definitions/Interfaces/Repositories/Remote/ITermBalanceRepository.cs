using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface ITermBalanceRepository
    {
        Task<TermBalance> GetBalanceForTermAsync(Term term);
    }
}
