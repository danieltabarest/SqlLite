using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IUserAccountRepository : IPersistenceRepository<UserProfile>
    {
        UserProfile Get();
    }
}
