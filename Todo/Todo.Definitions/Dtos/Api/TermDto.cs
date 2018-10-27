using Newtonsoft.Json;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    [JsonObject]
    public class TermDto : Base.JsonObject<Term>
    {
        [JsonProperty]
        public string Code
        {
            get;
            set;
        }

        [JsonProperty]
        public string Title
        {
            get;
            set;
        }

        public override Term ToDomainModel()
        {
            return new Term
			{
				Code = this.Code,
                Description = this.Title
			};
        }
    }
}
