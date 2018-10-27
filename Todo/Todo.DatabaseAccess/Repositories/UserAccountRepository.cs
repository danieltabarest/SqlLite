using System;
using System.Linq;
using NsuGo.Definition.Models;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Exceptions;
using NsuGo.DatabaseAccess.Repositories.Base;
using LocalData = Todo.LocalData.Models;
using NsuGo.Definition.Interfaces.Data;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class UserAccountRepository : LocalStorageRepository<UserProfile, LocalData.User>, IUserAccountRepository
    {
        public UserAccountRepository(IDataMapper<UserProfile, LocalData.User> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(UserProfile userAccount)
        {
            try
            {
                AddObject(userAccount);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to add a user account with id: ${userAccount.Id} to local storage.", ex);
            }
        }

        public UserProfile Get()
        {
            try
            {
                var userAccountFromDb = DatabaseProvider.GetItems<LocalData.User>().FirstOrDefault();

                if (userAccountFromDb == null)
                    return null;

                return MapToDomainModel(userAccountFromDb);
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
                throw new DataRepositoryException($"An error occurred while attempting to get user account from local storage.", ex);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all user accounts from local storage.", ex);
            }
        }

        public void Remove(UserProfile userProfile)
        {
            try
            {
                RemoveObject(userProfile);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove the user account with id: {userProfile.Id} from local storage.", ex);
            }
        }

        public void Update(UserProfile userProfile)
        {
			try
			{
                UpdateObject(userProfile);
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
				throw new DataRepositoryException($"An error occurred when an attempt was made to update the user account with id: {userProfile.Id} from local storage.", ex);
			}
        }
    }
}
