using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userAccountRepository)
        {
            _userProfileRepository = userAccountRepository;
        }

        public async Task<string> ProfileImageAsync()
        {
            return await _userProfileRepository.GetProfileImageAsync();
        }

        public async Task<UserProfile> UserProfileAsync()
        {
            return await _userProfileRepository.GetUserProfileAsync();
        }
    }
}
