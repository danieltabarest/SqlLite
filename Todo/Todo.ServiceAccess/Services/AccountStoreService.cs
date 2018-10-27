
using Todo.Common.Helpers;
using NsuGo.Definition.Interfaces.PlatformProviders;
using NsuGo.Definition.Interfaces.Services;

namespace NsuGo.ServiceAccess.Services
{
    public class AccountStoreService : IAccountStoreService
    {
        private readonly IKeychainProvider _keychainService;

        public AccountStoreService(IKeychainProvider keychainService)
        {
            _keychainService = keychainService;
        }

        public string Username => UserSettings.Username;

        public string Password => GetPassword();

        public bool Save(string username, string password)
        {
            UserSettings.Username = username;
            return _keychainService.SetPasswordForUsername(username, password, Preferences.AppId, false, out string errorCode);
        }

        private string GetPassword()
        {
            return _keychainService.GetPasswordForUsername(Username, Preferences.AppId, false) ?? string.Empty;
        }

    }
}
