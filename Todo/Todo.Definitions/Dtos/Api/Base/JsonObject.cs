namespace NsuGo.Definition.Dtos.Api.Base
{
    public abstract class JsonObject<DomainModel>
    {
        public abstract DomainModel ToDomainModel();
    }
}
