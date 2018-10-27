using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.DatabaseAccess.Repositories.Base;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class AccountSummaryRepository : LocalStorageRepository<AccountSummary, LocalData.AccountSummary>, IAccountSummaryRepository
    {
        public AccountSummaryRepository(IDataMapper<AccountSummary, LocalData.AccountSummary> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(AccountSummary accountSummary)
        {
            try
            {
                AddObject(accountSummary);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while attempting to add an accountSummary.", ex);
            }
        }

        public AccountSummary Get(string userId)
        {
            try
            {
                var accountSummaryFromDb = DatabaseProvider.GetItem<LocalData.AccountSummary, string>(userId);

                if (accountSummaryFromDb == null)
                    return null;

                return MapToDomainModel(accountSummaryFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while attempting to retrieve the account balance from local storage.", ex);
            }
        }

        public void RemoveAll()
        {
            try
            {
                RemoveAllObjects();
            }
            catch (DataRepositoryException)
            {
                throw;
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all account summary records from local storage.", ex);
            }
        }

        public void Remove(AccountSummary accountSummary)
        {
            try
            {
                RemoveObject(accountSummary);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while attempting to remove the account balance from local storage.", ex);
            }
        }

        public void Update(AccountSummary accountSummary)
        {
            try
            {
                UpdateObject(accountSummary);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while attempting to update the account balance that exists in local storage for current user", ex);
            }
        }

        public AccountSummary GetItem()
        {
            try
            {
                var accountSummaryFromDb = GetAccountSummaryFromDb().FirstOrDefault();

                if (accountSummaryFromDb == null)
                    return null;

                return MapToDomainModel(accountSummaryFromDb);
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while attempting to get the account summary from local storage.", ex);
            }
        }

        private IEnumerable<LocalData.AccountSummary> GetAccountSummaryFromDb()
        {
            return DatabaseProvider.GetItems<LocalData.AccountSummary>();
        }

        public bool IsEmpty()
        {
            return !GetAccountSummaryFromDb().Any();
        }
    }
}
