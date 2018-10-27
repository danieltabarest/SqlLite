using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> GetUserProfileAsync();

        Task<string> GetProfileImageAsync();
    }
}
