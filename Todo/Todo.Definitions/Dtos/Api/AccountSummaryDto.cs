namespace NsuGo.Definition.Dtos.Api
{
    public class AccountSummaryDto : Base.JsonObject<string>
    {
        public string TotalBalance
        {
            get;
            set;
        }

        public override string ToDomainModel()
        {
            return TotalBalance;
        }
    }
}
