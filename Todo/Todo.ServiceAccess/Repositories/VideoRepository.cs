using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IAPIContext _apiContext;

        public VideoRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<Video>> GetVideosForCourseAsync(string crn, int thumbnailHeight, int thumbnailWidth)
        {
            var uri = $"learning/CourseVideoData/user/crn/{crn}?thumbnailHeight={thumbnailHeight}&thumbnailWidth={thumbnailWidth}";
            var exceptionMessage = $"There was error while attempting to get videos for course with crn: {crn}";

            return await _apiContext.GetResourcesAsync<Video, VideoDto>(uri, exceptionMessage);
        }
    }
}
