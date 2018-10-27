using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface ITermManager
    {
        Task<Term> TermByCodeAsync(string code);
    }
}
