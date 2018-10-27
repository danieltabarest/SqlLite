using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface ITermRepository : IPersistenceRepository<Term>
    {
        Term Get(string code);

        IEnumerable<Term> GetAll();

        bool HasTermWithCode(string code);
    }
}
