using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IAPIContext _apiContext;

        public UserProfileRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<string> GetProfileImageAsync()
        {
            var uri = $"learning/UserData/user/image";
            var message = $"There was error while attempting to get profile image";

            return await _apiContext.GetResourceAsync(uri, message);

        }

        public async Task<UserProfile> GetUserProfileAsync()
        {
            var uri = $"learning/UserData/user";
            var message = $"There was error while attempting to get user profile";

            return await _apiContext.GetResourceAsync<UserProfile, UserProfileDto>(uri, message);
        }
    }
}
