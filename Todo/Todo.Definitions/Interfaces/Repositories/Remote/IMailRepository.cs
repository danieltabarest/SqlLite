using System.Threading.Tasks;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IMailRepository
    {
        Task<bool> SendMail(string to, string subject, string body);
    }
}
