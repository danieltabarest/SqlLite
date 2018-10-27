using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface IUserAccountManager
    {
        Task<UserProfile> UserProfileAsync();

        Task<System.IO.Stream> ProfileImageAsync();

        Task<bool> LoginAsync(string username, string password, bool saveUsername);

        void Logout();

        bool IsLoggedIn { get; }

        string SavedUsername { get; }
    }
}
