using NsuGo.Definition.Enums;

namespace NsuGo.Definition.Models
{
    public abstract class Meeting
    {
        public string CourseId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Description 
        { 
            get; 
            set; 
        }

        public string RegistrationUrl 
        { 
            get;
            set;
        }

		public string Type
		{
			get;
			set;
		}

        public abstract MeetingType MeetingType
        {
            get;
        }

        public abstract string DisplayIcon 
        { 
            get;
        }

        public abstract string DatePeriod 
        { 
            get;
        }

        public abstract string Duration 
        { 
            get;
        }
    }



}
