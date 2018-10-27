using System;

using NsuGo.Definition.Utilities;

namespace NsuGo.Definition.Models
{
    public class Grade
    {
        private const double _recentDurationInDays = 30;

		public string Id
		{
			get;
			private set;
		}

		public string CourseId
		{
			get;
			private set;
		}

		public string ContentId
		{
			get;
			private set;
		}

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

		public double PossibleGrade
		{
			get;
			set;
		}

		public bool IsCompleted
		{
			get;
			set;
		}

        public ListGroup Group
        {
            get;
            set;
        }

        public DateTime LastAssignmentSubmission
        {
            get;
            set;
        }

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

        public Grade()
        {
        }

        public Grade(
            string id, 
            string courseId,
            string contentId,
            string title,
            double actualGrade = 0.0,
            double possibleGrade = 1.0,
            bool isCompleted = false
        )
        {
            Id = id;
            CourseId = courseId;
            ContentId = contentId;
            Title = title;
            ActualGrade = actualGrade;
            PossibleGrade = possibleGrade;
            IsCompleted = isCompleted;
        }

        public string Result
        {
            get
            {
                if (IsCompleted)
                    return string.Format($"{ActualGrade}/{PossibleGrade}");
                
                return "Not yet graded";
            }
        }

      
        public void MarkAsRead()
        {
            IsUnread = false;
            FirstRead = DateTime.Now;
        }
    }
}
