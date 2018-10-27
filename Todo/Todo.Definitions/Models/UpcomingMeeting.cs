using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.Definition.Enums;

namespace NsuGo.Definition.Models
{
    public class UpcomingMeeting : Meeting
    {
        public int EventId 
        { 
            get; 
            set; 
        }

        public IEnumerable<Staff> Organizers 
        { 
            get; 
            set; 
        }

		public string TrainingId
		{
			get;
			set;
		}

		public string TrainingKey
		{
			get;
			set;
		}

        public string TrainingUrl 
        { 
            get; 
            set; 
        }

		public string ManagedUrl
		{
			get;
			set;
		}

        public IEnumerable<TimePeriod> Sessions
        {
            get;
            set;
        }

        public UpcomingMeeting()
        {
        }

        public UpcomingMeeting(int eventId, string description)
        {
            EventId = eventId;
            Description = description;
        }

		public override string DisplayIcon
		{
			get
			{
                return (MeetingType == MeetingType.OneTime) 
                        ? "Images/GotoTrainingOneTimeIcon.png" 
                        : "Images/GotoTrainingRecurringIcon.png";

            }
		}

		public override string DatePeriod
		{
			get
			{
                var startDate = Sessions.First().Start;
                var endDate = (MeetingType == MeetingType.OneTime) 
                            ? Sessions.First().End
                            : Sessions.Last().End;

                return startDate.ToMonthDayRangeFormattedString(endDate);
			}
		}

		public override string Duration
		{
			get
			{
				return string.Empty;
			}
		}

		public override MeetingType MeetingType
		{
			get
			{
				return (Sessions.Count() > 1) 
                    ? MeetingType.Recurring 
                    : MeetingType.OneTime;
			}
		}
    }
}
