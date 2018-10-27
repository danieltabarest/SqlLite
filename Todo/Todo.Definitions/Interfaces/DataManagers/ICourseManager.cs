using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;
using Todo;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface ICourseManager
    {
        Task<IEnumerable<Course>> CoursesAsync(bool refresh = false);

        Task<int> CourseCountAsync();

        Task<Course> CourseAsync(string courseId);

        Task<string> CourseNameByIdAsync(string courseId);

        Task SaveAsync(TodoItem todoItem);
    }
}
