namespace NsuGo.Definition.Dtos.Api
{
    public class MailDto
    {
        public string To
        {
            get;
            private set;
        }

        public string Subject
        {
            get;
            private set;
        }

        public string Body
        {
            get;
            private set;
        }

        public MailDto(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
