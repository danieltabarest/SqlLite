using System;
using System.Collections.Generic;
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
    public class CourseRepository : LocalStorageRepository<Course, LocalData.Course>, ICourseRepository
    {
        public CourseRepository(IDataMapper<Course, LocalData.Course> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(Course course)
        {
            try
            {
                AddObject(course);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to add a course with id: {course.Id} to local storage", ex);
            }
        }

        public Course Get(string courseId)
        {
            try
            {
                var courseFromDb = GetCourseFromDb(courseId);

                if (courseFromDb == null)
                    return null;

                return MapToDomainModel(courseFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occured while attempting to retrieve a course with id: {courseId} from local storage.", ex);
            }
        }

        private LocalData.Course GetCourseFromDb(string courseId)
        {
            return DatabaseProvider.GetItem<LocalData.Course, string>(courseId);
        }

        public IEnumerable<Course> GetAll()
        {
            try
            { 
                return MapAllToDomainModel(GetCoursesFromDb());
            }
            catch (LocalStorageException)
            {
                throw;   
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to retrieve all the current courses from local storage.", ex);
            }
        }

        private IEnumerable<LocalData.Course> GetCoursesFromDb()
        {
            return DatabaseProvider.GetItems<LocalData.Course>().ToList();
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all the courses from local storage.", ex);
            }
        }

        public void Remove(Course course)
        {
            try
            {
                RemoveObject(course);
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
                throw new DataRepositoryException($"An error occurred while attempting to remove a course with id: {course.Id}.", ex);
            }
        }

        public void Update(Course course)
        {
            try
            {
                UpdateObject(course);
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
                throw new DataRepositoryException($"An error occurred while attempting to update a course with the id: {course.Id}.", ex);
            }
        }

        public bool IsEmpty()
        {
            return !GetCoursesFromDb().Any();
        }

        public bool HasCourseWithId(string id)
        {
            return GetCourseFromDb(id) != null;
        }
    }
}
