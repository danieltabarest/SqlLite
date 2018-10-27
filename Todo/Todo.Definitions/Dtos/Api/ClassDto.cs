using Newtonsoft.Json;

namespace NsuGo.Definition.Dtos.Api
{
    [JsonObject]
    public class ClassDto
    {
        public string Crn
        {
            get;
            set;
        }

        public string TermCode
        {
            get;
            set;
        }

        public string StartDate
        {
            get;
            set;
        }

        public string EndDate
        {
            get;
            set;
        }

        public ClassDto()
        {
        }
    }
}
