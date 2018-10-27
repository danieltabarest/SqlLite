using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class TermMapper : IDataMapper<Definition.Models.Term, Term>
    {
        public Term ToData(Definition.Models.Term domain)
        {
            return new Term
            {
                Id = domain.Code,
                Code = domain.Code,
                Description = domain.Description,
                Status = domain.Status
            };
        }

        public Definition.Models.Term ToDomain(Term data)
        {
            return new Definition.Models.Term
            {
                Code = data.Code,
                Description = data.Description,
                Status = data.Status
            };
        }
    }
}
