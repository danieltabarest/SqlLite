using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    [JsonObject]
    public class CrosslistedCourseDto : Base.JsonObject<Course>
    {
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string SubjectCode
        {
            get;
            set;
        }

        public IEnumerable<ClassDto> Classes
        {
            get;
            set;
        }

        public override Course ToDomainModel()
        {
            var typicalClass = Classes.First();

            return new Course(Id, Name, DateTime.Parse(typicalClass.StartDate), DateTime.Parse(typicalClass.EndDate), CourseType.Other, true)
            {
                SubjectCode = SubjectCode,
                CRN = typicalClass.Crn,
                Term = new Term
                {
                    Code = typicalClass.TermCode
                }
            };
        }
    }
}
