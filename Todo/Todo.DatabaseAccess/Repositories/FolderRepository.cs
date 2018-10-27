using System;
using System.Collections.Generic;
using NsuGo.DatabaseAccess.Repositories.Base;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class FolderRepository : LocalStorageRepository<Folder, LocalData.Folder>, IFolderRepository
    {
        public FolderRepository(IDataMapper<Folder, LocalData.Folder> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(Folder folder)
        {
            try
            {
                AddObject(folder);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to add a folder having the id {folder.Id}.", ex);
            }
        }

        public Folder Get(string id)
        {
            try
            {
                var folderData = DatabaseProvider.GetItem<LocalData.Folder, string>(id);

                if (folderData == null)
                    return null;

                return MapToDomainModel(folderData);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to retrieve a folder that has the id {id}", ex);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all folders from local storage.", ex);
            }
        }

        public void Remove(Folder folder)
        {
            try
            {
                RemoveObject(folder);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove a folder having the id {folder.Id}", ex);
            }
        }

        public void Update(Folder folder)
        {
            try
            {
                UpdateObject(folder);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to update a folder having the id {folder.Id}", ex);
            }
        }
    }
}
