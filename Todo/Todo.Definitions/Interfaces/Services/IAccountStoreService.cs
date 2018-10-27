namespace NsuGo.Definition.Interfaces.Services
{
    public interface IAccountStoreService
    {
        string Username { get; }

        string Password { get; }

        bool Save(string username, string password);
    }
}
