namespace NsuGo.Definition.Interfaces.PlatformProviders
{
    public interface IKeychainProvider
    {
        bool SetPasswordForUsername(string username, string password, string serviceId, bool synchronizable, out string errorCode);

        string GetPasswordForUsername(string username, string serviceId, bool synchronizable);

        bool DeletePasswordForUsername(string username, string serviceId, bool synchronizable);
    }
}
