using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IAccountHoldRepository : IPersistenceRepository<AccountHold>
    {
        IEnumerable<AccountHold> GetAll();

        bool IsEmpty();
    }
}
