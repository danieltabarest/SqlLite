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
    public class StaffRepository : LocalStorageRepository<Staff, LocalData.Staff>, IStaffRepository
    {
        public StaffRepository(IDataMapper<Staff, LocalData.Staff> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(Staff staff)
        {
            try
            {
                AddObject(staff);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while an attempt was made to add a staff with id: {staff.Id}", ex);
            }
        }

        public Staff Get(string id)
        {
            try
            {
                var staffFromDb = DatabaseProvider.GetItem<LocalData.Staff, string>(id);

                if (staffFromDb == null)
                    return null;

                return MapToDomainModel(staffFromDb);
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while an attempt was made to retrieve the staff with id {id}.", ex);
            }
        }

        public IEnumerable<Staff> GetAll()
        {
            try
            {
                var staffsFromDb = DatabaseProvider.GetItems<LocalData.Staff>();
                return MapAllToDomainModel(staffsFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while an attempt was made to retrieve all staff members from local storage", ex);
            }
        }

        public void Remove(Staff staff)
        {
            try
            {
                RemoveObject(staff);
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
                throw new DataRepositoryException($"An error occurred while an attempt was made to remove a stafe from local storage with id: {staff.Id}.", ex);
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
                throw new DataRepositoryException("An error occurred when an attempt was made to remove all the staff from local storage.", ex);
            }
        }

        public void Update(Staff staff)
        {
            try
            {
                UpdateObject(staff);
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
                throw new DataRepositoryException($"An error occurred while an attempt was made to update a staff, with id {staff.Id}, in local storage.", ex);
            }
        }
    }
}
