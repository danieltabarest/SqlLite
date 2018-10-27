using System;
using Todo.LocalData.Models;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class CourseMapper : Base.BaseDataMapper, IDataMapper<Definition.Models.Course, Course>
    {
        public CourseMapper(IUserAccountRepository userAccountRepository)
            : base(userAccountRepository)
        {
        }

        public Course ToData(Definition.Models.Course domain)
        {
            var userId = GetUserId();

            return new Course
            {
                UserId = userId,
                Id = domain.Id,
                CourseId = domain.CourseId,
                TermCode = domain.Term.Code,
                SubjectCode = domain.SubjectCode,
                CourseCode = domain.CourseCode,
                SectionCode = domain.SectionCode,
                CRN = domain.CRN,
                CrosslistedCrn = domain.CrosslistedCrn,
                Name = domain.Name,
                InstructorName = domain.InstructorName,
                StartDate = domain.StartDate,
                EndDate = domain.EndDate,
                CourseType = domain.CourseType.ToString(),
                IsCrosslisted = domain.IsCrosslisted
            };
        }

        public Definition.Models.Course ToDomain(Course data)
        {
            var term = new Definition.Models.Term { Code = data.TermCode };

            return new Definition.Models.Course
            {
                Id = data.Id,
                CourseId = data.CourseId,
                Term = term,
                SubjectCode = data.SubjectCode,
                CourseCode = data.CourseCode,
                SectionCode = data.SectionCode,
                CRN = data.CRN,
                CrosslistedCrn = data.CrosslistedCrn,
                Name = data.Name,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CourseType = CourseTypeConverter(data.CourseType),
                IsCrosslisted = data.IsCrosslisted
            };
        }

        private CourseType CourseTypeConverter(string courseType)
        {
			try
			{
                return (CourseType)Enum.Parse(typeof(CourseType), courseType);
			}
			catch (Exception)
			{
                return CourseType.Other;
			}
        }
    }
}
