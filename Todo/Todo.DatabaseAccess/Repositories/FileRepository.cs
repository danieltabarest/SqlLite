using System;
using NsuGo.DatabaseAccess.Repositories.Base;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class FileRepository : LocalStorageRepository<File, LocalData.File>, IFileRepository
    {
        public FileRepository(IDataMapper<File, LocalData.File> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(File file)
        {
            try
            {
                AddObject(file);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to add a file having id {file.Id} to local storage.", ex);
            }
        }

        public File Get(string fileId)
        {
            try
            {
                var fileFromDb = DatabaseProvider.GetItem<LocalData.File, string>(fileId);

                if (fileFromDb == null)
                    return null;

                return MapToDomainModel(fileFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to retrieve a file that has the id: {fileId} from local storage.", ex);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all files from local storage.", ex);
            }
        }

        public void Remove(File file)
        {
            try
            {
                RemoveObject(file);
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
                throw new DataRepositoryException($"An error occurred while attempting to remove the file having {file.Id} from local storage.", ex);
            }
        }

        public void Update(File file)
        {
            try
            {
                UpdateObject(file);
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
                throw new DataRepositoryException($"An error occurred while attempting to update a file having the id {file.Id} that exists  in local storage.", ex);
            }
        }
    }
}