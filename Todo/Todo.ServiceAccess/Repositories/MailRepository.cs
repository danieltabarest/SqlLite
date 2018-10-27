using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;

namespace NsuGo.ServiceAccess.Repositories
{
    public class MailRepository : IMailRepository
    {
        private readonly IAPIContext _apiContext;

        public MailRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<bool> SendMail(string to, string subject, string body)
        {
            var uri = $"learning/Utility/sendemail";
            var message = $"There was an error while attempting to send email to: {to} with subject: {subject}";
            var mailDto = new MailDto(to, subject, body);

            return await _apiContext.PostActionAsync(uri, mailDto, message);
        }
    }
}
