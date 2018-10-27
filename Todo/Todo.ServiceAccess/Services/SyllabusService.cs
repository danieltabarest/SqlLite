using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class SyllabusService : ISyllabusService
    {
        private readonly ISyllabusRepository _syllabusRepository;

        public SyllabusService(ISyllabusRepository syllabusRepository)
        {
            _syllabusRepository = syllabusRepository;
        }

        public async Task<IEnumerable<Syllabus>> SyllabiForCourseAsync(Course course)
        {
            var syllabi = await _syllabusRepository.GetSyllabiForCourseAsync(course.CRN, course.Term.Code, course.IsCrosslisted);
            var endorsedSyllabi = syllabi.Where(s => s.Endorsed);
            return endorsedSyllabi;
        }
    }
}
