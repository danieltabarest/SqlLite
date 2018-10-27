namespace NsuGo.Definition.Models
{
    public class UserAccount
    {
        public string Username
        {
            get;
            set;
        }

        public UserAccount()
        {
        }

        public UserAccount(string username)
        {
            Username = username;
        }
    }
}
