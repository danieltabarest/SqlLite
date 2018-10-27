using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class StaffCourseRosterRepository : IStaffCourseRosterRepository
    {
        private readonly IDatabaseProvider _databaseProvider;
        private readonly IDataMapper<Staff, LocalData.Staff> _staffDataMapper;

        public StaffCourseRosterRepository(IDatabaseProvider databaseProvider, IDataMapper<Staff, LocalData.Staff> staffDataMapper)
        {
            _databaseProvider = databaseProvider;
            _staffDataMapper = staffDataMapper;
        }

        public void Add(Staff staff, Course course)
        {
            try
            {
                var staffId = staff.Id;
                var courseId = course.Id;

                var staffCourseRoster = new LocalData.StaffCourseRoster
                {
                    Id = $"{courseId}_{staffId}",
                    StaffId = staffId,
                    CourseId = courseId
                };

                _databaseProvider.InsertItem(staffCourseRoster);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while an attempt was made to add a staff-course with staff id {staff.Id} and course id {course.Id}.", ex);
            }
        }

        public IEnumerable<string> GetStaffIdsForCourse(Course course)
        {
            try
            {
                var staffIds = new List<string>();

                foreach (var staff in GetStaffsFromDb(course))
                    staffIds.Add(staff.StaffId);

                return staffIds;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An erorr occurred while an attempt was made to retrieve the staff members for course, with id = {course.Id}, from local storage.", ex);
            }
        }

        private IEnumerable<LocalData.StaffCourseRoster> GetStaffsFromDb(Course course)
        {
            return _databaseProvider.QueryDb<LocalData.StaffCourseRoster>("SELECT * FROM StaffCourseRoster WHERE CourseId =?", course.Id);
        }

        public bool HasStaffForCourse(Course course)
        {
            return GetStaffsFromDb(course).Any();
        }

        public void Remove(Staff staff, Course course)
        {
            try
            {
                var id = $"{course.Id}_{staff.Id}";
                var rosterToDelete = _databaseProvider.GetItem<LocalData.StaffCourseRoster, string>(id);

                _databaseProvider.DeleteItem(rosterToDelete);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred while an attempt was made to remove a staff-course with course id {course.Id} and staff id {staff.Id}.", ex);
            }

        }

        public void RemoveAll()
        {
            try
            {
                var count = _databaseProvider.GetItems<LocalData.StaffCourseRoster>().Count();
                var removedCount = _databaseProvider.DeleteItems<LocalData.StaffCourseRoster>();

                if (count != removedCount)
                    throw new DataRepositoryException($"{removedCount}/{count} staff_courses were removed from local storage when an attempt was made to remove all staff_course roster items.");
            }
            catch (DataRepositoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred while an attempt was made to remove all staff_course rosters.", ex);
            }
        }

        private IEnumerable<Staff> MapAllToStaffDomainModel(IEnumerable<LocalData.Staff> staffsFromDb)
        {
            var staffs = new List<Staff>();

            foreach (var staffFromDb in staffsFromDb)
                staffs.Add(_staffDataMapper.ToDomain(staffFromDb));

            return staffs;
        }
    }
}
