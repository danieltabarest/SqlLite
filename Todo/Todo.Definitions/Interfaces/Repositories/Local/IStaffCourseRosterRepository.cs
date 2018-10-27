using System.Collections.Generic;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IStaffCourseRosterRepository
    {
        void Add(Staff staff, Course course);

        void Remove(Staff staff, Course course);

        IEnumerable<string> GetStaffIdsForCourse(Course course);

        void RemoveAll();

        bool HasStaffForCourse(Course course);
    }
}
