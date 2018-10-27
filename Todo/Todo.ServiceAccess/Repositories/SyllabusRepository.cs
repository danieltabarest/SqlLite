using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories
{
    public class SyllabusRepository : ISyllabusRepository
    {
        private readonly IAPIContext _apiContext;

        public SyllabusRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<Syllabus>> GetSyllabiForCourseAsync(string crn, string termCode, bool isCrosslistedCourse)
        {
            var uri = $"learning/CourseData/content/syllabi?termCode={termCode}&crn={crn}&crossListedCourse={isCrosslistedCourse}";
            var exceptionMessage = $"There was error while attempting to get syllabi for course with crn: {crn} and term code: {termCode}.";

            return await _apiContext.GetResourcesAsync<Syllabus, SyllabusDto>(uri, exceptionMessage);
        }
    }
}
