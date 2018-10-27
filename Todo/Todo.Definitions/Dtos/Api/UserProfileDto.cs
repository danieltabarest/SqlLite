using Newtonsoft.Json;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    [JsonObject]
    public class UserProfileDto : Base.JsonObject<UserProfile>
    {
        [JsonProperty]
        public string NsuId
        {
            get;
            set;
        }

        [JsonProperty]
        public string UserName
        {
            get;
            set;
        }

        [JsonProperty]
        public string FullName
        {
            get;
            set;
        }

        [JsonProperty]
        public string EmailAddress
        {
            get;
            set;
        }

        public override UserProfile ToDomainModel()
        {
            return new UserProfile(UserName, EmailAddress)
            {
                NsuId = NsuId,
                Username = UserName,
                Name = FullName
            };
        }
    }
}
