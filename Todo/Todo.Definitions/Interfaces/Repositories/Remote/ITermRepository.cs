using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface ITermRepository
    {
        Task<Term> GetTermByCode(string code);
    }
}
