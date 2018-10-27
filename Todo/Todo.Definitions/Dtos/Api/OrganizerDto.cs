using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class OrganizerDto : Base.JsonObject<Staff>
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public override Staff ToDomainModel()
        {
            return new Staff
            {
                Name = $"{FirstName} {LastName}",
                EmailAddress = Email
            };
        }
    }
}
