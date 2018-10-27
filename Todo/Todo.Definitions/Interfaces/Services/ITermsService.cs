using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface ITermsService
    {
        Task<Term> TermByCodeAsync(string code);
    }
}
