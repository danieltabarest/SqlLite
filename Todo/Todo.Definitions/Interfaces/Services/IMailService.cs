using System.Threading.Tasks;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IMailService
    {
        Task<bool> SendMail(string to, string subject, string body);
    }
}
