using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IFileRepository : IPersistenceRepository<File>
    {
        File Get(string fileId);
    }
}
