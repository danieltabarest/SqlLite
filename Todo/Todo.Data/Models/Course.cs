using System;
using Todo.LocalData.Base;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Course")]
    public class Course : PersistenceEntityBase
    {
        [MaxLength(10)]
        [NotNull]
        public string UserId
        {
            get;
            set;
        }

        [NotNull]
        [MaxLength(100)]
		public string CourseId
		{
			get;
			set;
		}

        [MaxLength(6)]
        [NotNull]
        [Indexed]
        public string TermCode
		{
			get;
			set;
		}

        [MaxLength(10)]
		public string SubjectCode
		{
			get;
			set;
		}

        [MaxLength(10)]
		public string CourseCode
		{
			get;
			set;
		}

        [MaxLength(10)]
		public string SectionCode
		{
			get;
			set;
		}

        [MaxLength(20)]
		public string CRN
		{
			get;
			set;
		}

        [MaxLength(20)]
        public string CrosslistedCrn
        {
            get;
            set;
        }

        [NotNull]
        [MaxLength(256)]
		public string Name
		{
			get;
			set;
		}

        [MaxLength(100)]
		public string InstructorName
		{
			get;
			set;
		}

        [NotNull]
		public DateTime StartDate
		{
			get;
			set;
		}

        [NotNull]
		public DateTime EndDate
		{
			get;
			set;
		}

        [NotNull]
        [MaxLength(15)]
        public string CourseType
		{
			get;
			set;
		}

        [NotNull]
		public bool IsCrosslisted
		{
			get;
			set;
		}

        public Course()
        {
            DidSyncToLocalStorage();
        }
    }
}
