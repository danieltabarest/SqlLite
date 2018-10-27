using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class GradesService : IGradesService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradesService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<Grade>> GradesForCourseAsync(Course course)
        {
            return await _gradeRepository.GetGradesAsync(course.Id);
        }

        public async Task<IEnumerable<Grade>> GradesAsync()
        {
            return await _gradeRepository.GetGradesAsync();
        }
    }
}
