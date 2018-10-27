using System.Threading.Tasks;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IAuthenticationService
	{
		Task<bool> AuthenticateAsync(string username, string password);

        void Logout();
				
        Task<string> GetAccessTokenAsync();
		
        string GetEncodedCredentials();

        bool IsLoggedIn { get; }

        string AccessToken { get; }

        string RefreshToken { get; }
	}
}
