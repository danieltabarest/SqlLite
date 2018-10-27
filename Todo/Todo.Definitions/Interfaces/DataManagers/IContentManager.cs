using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.DataManagers
{
    public interface IContentManager
    {
        Task<IEnumerable<Content>> ContentForCourseAsync(Course course, bool refresh = false);

        Task<IEnumerable<Content>> ContentInFolderForCourseAsync(Course course, Folder folder, bool refresh = false);

        Task<IEnumerable<Syllabus>> SyllabiForCourseAsync(Course course);

        Task<IEnumerable<Video>> VideosForCourseAsync(Course course, int thumbnailWidth, int thumbnailHeight);
    }
}
