using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IFolderRepository : IPersistenceRepository<Folder>
    {
        Folder Get(string id);
    }
}
