using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetVideosForCourseAsync(string crn, int thumbnailHeight, int thumbnailWidth);
    }
}
