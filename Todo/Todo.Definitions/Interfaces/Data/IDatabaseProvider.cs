using System.Collections.Generic;

namespace NsuGo.Definition.Interfaces.Data
{
    public interface IDatabaseProvider
    {
        TResult GetItem<TResult, TQuery>(TQuery id)
            where TResult : IPersistableEntity, new();

        IEnumerable<TResult> GetItems<TResult>()
            where TResult : IPersistableEntity, new();

        int InsertItem<TItem>(TItem item)
            where TItem : IPersistableEntity, new();

        int InsertOrReplaceItem<TItem>(TItem item)
            where TItem : IPersistableEntity, new();

        int InsertItems<TItem>(IEnumerable<TItem> items, bool runInTransaction = true)
            where TItem : IPersistableEntity, new();

        int DeleteItem<TItem>(TItem item)
            where TItem : IPersistableEntity, new();

        int DeleteItems<TItem>()
            where TItem : IPersistableEntity, new();

        int UpdateItem<TItem>(TItem item)
            where TItem : IPersistableEntity, new();

        int UpdateItems<TItem>(IEnumerable<TItem> items)
            where TItem : IPersistableEntity, new();

        IEnumerable<TResult> QueryDb<TResult>(string query, params object[] args)
            where TResult : IPersistableEntity, new();

        int ExecuteQuery(string query, params object[] args);
    }
}
