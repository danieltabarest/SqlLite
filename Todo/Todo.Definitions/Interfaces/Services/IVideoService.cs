using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> VideosForCourseAsync(string crn, int thumbnailHeight, int thumbnailWidth);
    }
}
