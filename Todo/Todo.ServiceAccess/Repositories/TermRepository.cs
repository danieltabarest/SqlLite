using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class TermRepository : ITermRepository
    {
        private readonly IAPIContext _apiContext;

        public TermRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Term> GetTermByCode(string code)
        {
			var uri = $"learning/CourseData/term?code={code}";
			var message = $"There was an error while attempting to get the term with code: {code}";

            return (await _apiContext.GetResourcesAsync<Term, TermDto>(uri, message)).FirstOrDefault();
        }
    }
}
