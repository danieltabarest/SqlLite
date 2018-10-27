using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;


        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<IEnumerable<Video>> VideosForCourseAsync(string crn, int thumbnailHeight, int thumbnailWidth)
        {
            return await _videoRepository.GetVideosForCourseAsync(crn, thumbnailHeight, thumbnailWidth);
        }
    }
}
