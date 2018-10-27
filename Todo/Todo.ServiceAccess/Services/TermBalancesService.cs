using System;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class TermBalancesService : ITermBalancesService
    {
        private readonly ITermBalanceRepository _termBalanceRepository;
        private readonly ITermsService _termsService;

        public TermBalancesService(ITermBalanceRepository termBalanceRepository, ITermsService termsService)
        {
            _termBalanceRepository = termBalanceRepository;
            _termsService = termsService;
        }

        public Task<TermBalance> CurrentTermBalanceAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TermBalance> TermBalanceAsync(Term term)
        {
            var balance = await _termBalanceRepository.GetBalanceForTermAsync(term);
            return TermBalanceOrDefault(term, balance);
        }

        private TermBalance TermBalanceOrDefault(Term term, TermBalance balance)
        {
            if (balance == null)
            {
                return new TermBalance(term, 0.0m, 0.0m, 0.0m);
            }

            return balance;
        }
    }
}
