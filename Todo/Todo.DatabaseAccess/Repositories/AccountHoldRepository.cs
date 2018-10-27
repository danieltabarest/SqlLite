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
    public class AccountHoldRepository : LocalStorageRepository<AccountHold, LocalData.AccountHold>, IAccountHoldRepository
    {
        public AccountHoldRepository(IDataMapper<AccountHold, LocalData.AccountHold> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(AccountHold accountHold)
        {
            try
            {
                AddObject(accountHold);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to add an account hold with id: {accountHold.HoldType} into the local storage.", ex);
            }
        }

        public IEnumerable<AccountHold> GetAll()
        {
            try
            {
                return MapAllToDomainModel(GetAccountHoldsFromDb());
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while attempting to retrieve all account holds from local storage", ex);
            }
        }

        private IEnumerable<LocalData.AccountHold> GetAccountHoldsFromDb()
        {
            return DatabaseProvider.GetItems<LocalData.AccountHold>().ToList();
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all account holds from local storage.", ex);
            }
        }

        public void Remove(AccountHold accountHold)
        {
            try
            {
                RemoveObject(accountHold);
            }
            catch(DataRepositoryException)
            {
                throw;
            }
            catch(LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occured while attempting to remove an account hold of type: {accountHold.HoldType} that started {accountHold.Start}", ex);
            }
        }

        public void Update(AccountHold accountHold)
        {
            try
            {
                UpdateObject(accountHold);
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
                throw new DataRepositoryException($"An error occured while attempting to update an account hold of type: {accountHold.HoldType} that starts {accountHold.Start}, that exists in local storage.", ex);
            }
        }

        public bool IsEmpty()
        {
            return !GetAccountHoldsFromDb().Any();
        }
    }
}
