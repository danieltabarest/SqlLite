using System;
using NsuGo.Definition.Interfaces.Data;
using SQLite;

namespace Todo.LocalData.Base
{
    public abstract class PersistenceEntityBase : IPersistableEntity
    {
        [PrimaryKey]
        [MaxLength(10)]
        public string Id
        {
            get;
            set;
        }

        [NotNull]
        public DateTime LastSynced
        {
            get;
            set;
        }

        public virtual void DidSyncToLocalStorage()
        {
            LastSynced = DateTime.Now;
        }
    }
}
