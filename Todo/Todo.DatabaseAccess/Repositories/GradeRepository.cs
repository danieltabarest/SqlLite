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
    public class GradeRepository : LocalStorageRepository<Grade, LocalData.Grade>, IGradeRepository
    {
        public GradeRepository(IDataMapper<Grade, LocalData.Grade> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(Grade grade)
        {
            try
            {
                AddObject(grade);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while an attempt was made to add a grade with id: {grade.Id} to local storage.", ex);
            }
        }

        public IEnumerable<Grade> GetAllWithCourseId(string courseId)
        {
            try
            {
                var gradesFromDb = GetGradesFromDb(courseId);
                return MapAllToDomainModel(gradesFromDb).ToList();
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while an attempt was made to get all the grades from local storage for the course with id: {courseId}.", ex);
            }
        }

        private IEnumerable<LocalData.Grade> GetGradesFromDb(string courseId)
        {
            return DatabaseProvider.QueryDb<LocalData.Grade>("SELECT * FROM Grade WHERE CourseId = ?", courseId);
        }

        public IEnumerable<Grade> GetAll()
        {
            try
            {
                return MapAllToDomainModel(GetGradesFromDb()).ToList();
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while an attempt was made to retrieve all grades from local storage.", ex);
            }
        }

        private IEnumerable<LocalData.Grade> GetGradesFromDb()
        {
            return DatabaseProvider.GetItems<LocalData.Grade>();
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all the grades from local storage.", ex);
            }
        }

        public void Remove(Grade grade)
        {
            try
            {
                RemoveObject(grade);
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
                throw new DataRepositoryException($"An error occurred while an attempt was made to remove a grade from local storage having the id: {grade.Id}", ex);
            }
        }

        public void Update(Grade grade)
        {
			try
			{
                UpdateObject(grade);
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
				throw new DataRepositoryException($"An error occurred while an attempt was made to update a grade from local storage having the id: {grade.Id}", ex);
			}
        }

        public Grade Get(string id)
        {
            try
            {
                var gradeFromDb = DatabaseProvider.GetItem<LocalData.Grade, string>(id);

                if (gradeFromDb == null)
                    return null;

                return MapToDomainModel(gradeFromDb);
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while an attempt was made to retrieve the grade with id {id} from local storage.", ex);
            }
        }

        public bool IsEmpty()
        {
            return !GetGradesFromDb().Any();
        }

        public bool HasGradesForCourseWithId(string courseId)
        {
            return GetGradesFromDb(courseId).Any();
        }
    }
}
