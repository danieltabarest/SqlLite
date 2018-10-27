using System;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeTermBalanceRepository : ITermBalanceRepository
    {
        public FakeTermBalanceRepository(ITermsService termsService)
        {
            throw new NotSupportedException();
        }

        public Task<TermBalance> GetBalanceForTermAsync(Term term)
        {
            throw new NotSupportedException();
        }
    }
}