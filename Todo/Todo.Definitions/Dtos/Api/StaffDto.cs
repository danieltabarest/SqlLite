using Newtonsoft.Json;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    [JsonObject]
    public class StaffDto : Base.JsonObject<Staff>
    {
        [JsonProperty]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty]
        public string Name
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

        [JsonProperty]
        public string OfficeAddress
        {
            get;
            set;
        }

        [JsonProperty]
        public string OfficeHours
        {
            get;
            set;
        }

        [JsonProperty]
        public string Phone
        {
            get;
            set;
        }

        public override Staff ToDomainModel()
        {
            return new Staff
            {
                Id = Id,
                Name = Name,
                EmailAddress = EmailAddress,
                OfficeAddress = OfficeHours,
                OfficeHours = OfficeHours,
                Phone = Phone
            };
        }
    }
}
