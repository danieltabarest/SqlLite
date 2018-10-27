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
    public class AssignmentRepository : LocalStorageRepository<Assignment, LocalData.Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(IDataMapper<Assignment, LocalData.Assignment> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(Assignment assignment)
        {
            try
            {
                AddObject(assignment);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to add an assignment with the id: {assignment.Id} to local storage.", ex);
            }
        }

        public IEnumerable<Assignment> GetAllWithCourseId(string courseId)
        {
            try
            {
                var courseAssignmentsFromDb = GetAssignmentsFromDb(courseId);
                return MapAllToDomainModel(courseAssignmentsFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to retrieve all the assignments for the course with id {courseId} from local storage.", ex);
            }
        }

        private IEnumerable<LocalData.Assignment> GetAssignmentsFromDb(string courseId)
        {
            return DatabaseProvider.QueryDb<LocalData.Assignment>("SELECT * FROM Assignment WHERE CourseId = ?", courseId).ToList();
        }

        public IEnumerable<Assignment> GetAll()
        {
            try
            {
                var assignmentsFromDb = GetAssignmentsFromDb();
                return MapAllToDomainModel(assignmentsFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to retrieve all assignments.", ex);
            }
        }

        private IEnumerable<LocalData.Assignment> GetAssignmentsFromDb()
        {
            return DatabaseProvider.GetItems<LocalData.Assignment>().ToList();
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all the assignments from local storage.", ex);
            }
        }

        public void Remove(Assignment assignment)
        {
            try
            {
                RemoveObject(assignment);
            }
            catch(DataRepositoryException)
            {
                throw;
            }
            catch (LocalStorageException)
            {
                throw;   
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove an assignment having the id {assignment.Id} from the local storage.", ex);
            }
        }

        public void Update(Assignment assignment)
        {
			try
			{
                UpdateObject(assignment);
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
				throw new DataRepositoryException($"An error occurred when an attempt was made to update an assignment having the id {assignment.Id} existing in local storage.", ex);
			}
        }

        public bool HasAssignmentsWithCourseId(string courseId)
        {
            return GetAssignmentsFromDb(courseId).Any();
        }

        public bool IsEmpty()
        {
            return !GetAssignmentsFromDb().Any();
        }
    }
}
