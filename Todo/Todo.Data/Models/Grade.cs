using System;
using Todo.LocalData.Base;
using NsuGo.Definition.Interfaces.Data;
using SQLite;

namespace Todo.LocalData.Models
{
    [Table("Grade")]
    public class Grade : PersistenceEntityBase, IReadable
    {
        
        [MaxLength(10)]
        [NotNull]
        public string UserId
        {
            get;
            set;
        }

        [MaxLength(10)]
        [NotNull]
		public string CourseId
		{
			get;
			set;
		}

        [MaxLength(10)]
		public string ContentId
		{
			get;
			set;
		}

        [MaxLength(128)]
        [NotNull]
		public string Title
		{
			get;
			set;
		}

		public double ActualGrade
		{
			get;
			set;
		}

        [NotNull]
		public double PossibleGrade
		{
			get;
			set;
		}

        [NotNull]
		public bool IsCompleted
		{
			get;
			set;
		}

        [NotNull]
        public bool IsUnread
        {
            get;
            set;
        }

        public DateTime FirstRead
        {
            get;
            set;
        }

		[NotNull]
		public DateTime LastAssignmentSubmission
		{
			get;
			set;
		}

		public Grade()
        {
            DidSyncToLocalStorage();
        }
    }
}
