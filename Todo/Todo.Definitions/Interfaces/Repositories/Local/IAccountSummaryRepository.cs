using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IAccountSummaryRepository : IPersistenceRepository<AccountSummary>
    {
        AccountSummary GetItem();

        AccountSummary Get(string userId);

        bool IsEmpty();
    }
}
