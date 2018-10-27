using NsuGo.Definition.Interfaces.Data;

namespace NsuGo.Definition.Interfaces
{
    public interface IDataMapper<TDomainModel, TDataModel> 
        where TDomainModel: class
        where TDataModel : IPersistableEntity
    {
        TDomainModel ToDomain(TDataModel data);

        TDataModel ToData(TDomainModel domain);
    }
}
