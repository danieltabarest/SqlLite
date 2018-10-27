using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.DatabaseAccess.Repositories.Base;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class AnnouncementRepository : LocalStorageRepository<Announcement, LocalData.Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(IDataMapper<Announcement, LocalData.Announcement> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(Announcement announcement)
        {
            try
            {
                AddObject(announcement);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to add an announcement with id {announcement.Id} to the local storage database.", ex);
            }
        }

        public IEnumerable<Announcement> GetAll()
        {
            try
            {
                return MapAllToDomainModel(GetAnnouncementsFromDb());
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to get all announcements from local storage.", ex);
            }
        }

        private IEnumerable<LocalData.Announcement> GetAnnouncementsFromDb()
        {
            return DatabaseProvider.GetItems<LocalData.Announcement>().ToList();
        }

        public IEnumerable<Announcement> GetAllWithCourseId(string courseId)
        {
            try
            {
                var announcementsFromDb = GetAnnouncementsFromDb(courseId);
                return MapAllToDomainModel(announcementsFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to get the announcements for the course with id: {courseId}.", ex);
            }
        }

        private IEnumerable<LocalData.Announcement> GetAnnouncementsFromDb(string courseId)
        {
            return DatabaseProvider.QueryDb<LocalData.Announcement>("SELECT * FROM Announcement WHERE CourseId = ?", courseId).ToList();
        }

        public IEnumerable<Announcement> GetCourseAnnouncements()
        {
            try
            {
                return GetAnnouncementsOfType(AnnouncementType.Course);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Announcement> GetSystemAnnouncements()
        {
            try
            {
                return GetAnnouncementsOfType(AnnouncementType.System);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IEnumerable<Announcement> GetAnnouncementsOfType(AnnouncementType announcementType)
        {
            try
            {
                var announcementsFromDb = GetAnnouncementsFromDb(announcementType);
                return MapAllToDomainModel(announcementsFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to get the {announcementType} announcements.", ex);
            }
        }

        private IEnumerable<LocalData.Announcement> GetAnnouncementsFromDb(AnnouncementType announcementType)
        {
            return DatabaseProvider.QueryDb<LocalData.Announcement>("SELECT * FROM Announcement WHERE Type = ?", announcementType.ToString()).ToList();
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all the announcements from local storage.", ex);
            }
        }

        public void Remove(Announcement announcement)
        {
            try
            {
                RemoveObject(announcement);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove the announcement with the id: {announcement.Id} from local storage.", ex);
            }
        }

        public void Update(Announcement announcement)
        {
			try
			{
                UpdateObject(announcement);
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
				throw new DataRepositoryException($"An error occurred when an attempt was made to update the announcement with the id: {announcement.Id} from local storage.", ex);
			}
        }

        public Announcement Get(string id)
        {
            try
            {
                var announcementFromDb = DatabaseProvider.GetItem<LocalData.Announcement, string>(id);

                if (announcementFromDb == null)
                    return null;

                return MapToDomainModel(announcementFromDb);
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while attempting to get the announcement with id {id}.", ex);
            }
        }

        public bool IsEmpty()
        {
            return !GetAnnouncementsFromDb().Any();
        }

        public bool HasSystemAnnouncements()
        {
            return GetAnnouncementsFromDb(AnnouncementType.System).Any();
        }

        public bool HasAnnouncementsWithCourseId(string courseId)
        {
            return GetAnnouncementsFromDb(courseId).Any();
        }
    }
}
