using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.Definition.Enums;

namespace NsuGo.Definition.Models
{
    public class Course
	{
		public string Id
		{
			get;
			set;
		}

		public string CourseId
		{
			get;
			set;
		}

		public Term Term
		{
			get;
			set;
		}

		public string SubjectCode
		{
			get;
			set;
		}

		public string CourseCode
		{
			get;
			set;
		}

		public string SectionCode
		{
			get;
			set;
		}

		public string CRN
		{
			get;
			set;
		}

        public string CrosslistedCrn
        {
            get;
            set;
        }

        public string Name
		{
			get;
			set;
		}

        public IEnumerable<Staff> Instructors
        {
            get;
            set;
        }

        public string InstructorName => (Instructors != null && Instructors.Any()) ? Instructors.First().Name : string.Empty;

        public DateTime StartDate
		{
			get;
			set;
		}

		public DateTime EndDate
		{
			get;
			set;
		}

		public CourseType CourseType
		{
			get;
			set;
		}

        public Utilities.ListGroup Group
        {
            get;
            set;
        }

        public bool IsCrosslisted
        {
            get;
            set;
        }

        public Course()
        {
        }

        public Course(string id, string name, DateTime startDate, DateTime endDate, CourseType type, bool isCrosslisted)
		{
			Id = id;
			Name = name;
			StartDate = startDate;
			EndDate = endDate;
			CourseType = type;
            IsCrosslisted = isCrosslisted;
		}
	}
}