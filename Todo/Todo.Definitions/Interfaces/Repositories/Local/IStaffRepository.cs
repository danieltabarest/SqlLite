using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IStaffRepository : IPersistenceRepository<Staff>
    {
        Staff Get(string id);

        IEnumerable<Staff> GetAll();
    }
}
