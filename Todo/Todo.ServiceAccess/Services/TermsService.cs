using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class TermsService : ITermsService
    {
        private readonly ITermRepository _termRepository;

        public TermsService(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        public async Task<Term> TermByCodeAsync(string code)
        {
            return await _termRepository.GetTermByCode(code);
        }
    }
}
