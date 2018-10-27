using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;
using NsuGo.Definition.Utilities;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeTermRepository : ITermRepository
    {
        private readonly IEnumerable<Term> _terms;

        public FakeTermRepository()
        {
            _terms = new List<Term>
            {
				new Term
				{
					Code = "201650",
					Description = "Summer I 2016",
					Status = TermStatus.other
				},
				new Term
				{
					Code = "201550",
					Description = "Summer I 2015",
					Status = TermStatus.other
				},
				new Term
				{
					Code = "201720",
					Description = "Fall 2016",
                    Status = TermStatus.other
				},
				new Term
				{
					Code = "201730",
					Description = "Winter 2017",
                    Status = TermStatus.previous
				},
				new Term
				{
					Code = "201750",
					Description = "Summer I 2017",
					Status = TermStatus.current
				},
				new Term
				{
					Code = "201400",
					Description = "2013-14 ContinuingEd/Prof Dev",
                    Status = TermStatus.other
				}
            };
        }

        public async Task<Term> GetCurrentTerm()
        {
            await Task.Delay(1000);
            return _terms.SingleOrDefault(t => t.Status == TermStatus.current);
        }

        public async Task<Term> GetPreviousTerm()
        {
            await Task.Delay(1000);
            return _terms.SingleOrDefault(t => t.Status == TermStatus.previous);
        }

        public async Task<IEnumerable<Term>> GetTerms()
        {
            await Task.Delay(1000);
            return _terms.ToList();
        }

        public async Task<Term> GetTermByCode(string code)
        {
            await Task.Delay(1000);
            return _terms.SingleOrDefault(t => t.Code == code);
        }
    }
}
