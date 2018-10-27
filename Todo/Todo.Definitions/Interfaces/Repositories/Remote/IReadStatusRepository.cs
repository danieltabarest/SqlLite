using System.Threading.Tasks;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IReadStatusRepository
    {
        Task AddAsync(string id, string entity);

        bool IsExists(string id, string entity);

        void Reset();
    }
}
