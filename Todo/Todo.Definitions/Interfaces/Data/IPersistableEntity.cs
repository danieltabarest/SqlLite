using System;
namespace NsuGo.Definition.Interfaces.Data
{
    public interface IPersistableEntity
    {
        string Id
        {
            get;
            set;
        }

        DateTime LastSynced
        {
            get;
            set;
        }
    }
}
