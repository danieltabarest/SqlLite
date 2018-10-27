using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IUserProfileService
    {
        Task<UserProfile> UserProfileAsync();

        Task<string> ProfileImageAsync();
    }
}
