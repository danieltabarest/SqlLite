using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;

namespace NsuGo.ServiceAccess.Services
{
    public class MailService : IMailService
    {
        private readonly IMailRepository _mailRepository;

        public MailService(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        public async Task<bool> SendMail(string to, string subject, string body)
        {
            System.Diagnostics.Debug.WriteLine($"Sending mail... \n To: {to} \n Subject: {subject} \n Message: {body}");
            return await _mailRepository.SendMail(to, subject, body);
        }
    }
}
