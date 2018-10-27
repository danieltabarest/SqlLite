using System;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Utilities;

namespace NsuGo.Definition.Models
{
    public class Assignment
	{
		private static readonly DateTime _today = DateTime.Now;
		private static readonly DateTime _oneWeek = DateTime.Now.AddDays(7);
		private static readonly DateTime _twoWeeks = DateTime.Now.AddDays(14);
		private static readonly DateTime _threeWeeks = DateTime.Now.AddDays(21);

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

        public string Name
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }

        public ListGroup Group
        {
            get;
            set;
        }

        public String DueDateFormatted
        {
            get {
                return DueDate.ToFormattedString();
            }
        }

        public DatePeriod DueDatePeriod
        {
            get
            {
                return DetermineDatePeriod();
            }
        }

        protected DatePeriod DetermineDatePeriod()
        {
            if (this.DueDate >= _today && this.DueDate < _oneWeek)
                return DatePeriod.ThisWeek;
            
            else if (this.DueDate >= _oneWeek && this.DueDate < _twoWeeks)
                return DatePeriod.OneWeekFromNow;
            
            else if (this.DueDate >= _twoWeeks && this.DueDate < _threeWeeks)
                return DatePeriod.TwoWeeksFromNow;
            
            else if (this.DueDate < _today)
                return DatePeriod.Past;
            
            else
                return DatePeriod.DistantFuture;
        }

        public bool IsUpcoming
        {
            get 
            {
                return DueDatePeriod != DatePeriod.Past;
            }
        }
    }
}