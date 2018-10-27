using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Models;
using NsuGo.Definition.Utilities;

namespace NsuGo.Definition.Dtos.Api
{
    [JsonObject]
    public class CourseDto : Base.JsonObject<Course>
    {

        [JsonProperty]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty]
        public string CourseId
        {
            get;
            set;
        }

        [JsonProperty]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty]
        public string StartDate
        {
            get;
            set;
        }

        [JsonProperty]
        public string EndDate
        {
            get;
            set;
        }

        [JsonProperty]
        public string TermCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string SubjectCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string CourseCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string SectionCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string Crn
        {
            get;
            set;
        }

        [JsonProperty]
        public string CourseType
        {
            get;
            set;
        }

        [JsonProperty]
        public bool CrossListedCourse
        {
            get;
            set;
        }

        [JsonProperty]
        public List<StaffDto> Staffs
        {
            get;
            set;
        }

        public override Course ToDomainModel()
        {
            return new Course(Id, Name, DateTime.Parse(StartDate), DateTime.Parse(EndDate), CourseTypeConverter(CourseType), CrossListedCourse)
            {
                Instructors = MappedInstructors(),
                Term = new Term
                {
                    Code = TermCode,
                    Status = TermStatus.current
                },
                CourseId = CourseId,
                SubjectCode = SubjectCode,
                CourseCode = CourseCode,
                SectionCode = SectionCode,
                CRN = Crn
            };
        }

        private CourseType CourseTypeConverter(string courseType)
        {
            switch(courseType)
            {
                case "Banner":
                    return Enums.CourseType.AcademicCourse;

                case "Training":
                    return Enums.CourseType.TrainingCourse;

                default:
                    return Enums.CourseType.Other;      
            }
        }

        private IEnumerable<Staff> MappedInstructors()
        {
            return Staffs.Select(staff => {
                return staff.ToDomainModel();
            });
        }

    }
}
