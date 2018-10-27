using System;

namespace NsuGo.Definition.Models
{
    public class TimePeriod
    {
        public DateTime Start
        {
            get;
            set;
        }

        public DateTime End
        {
            get;
            set;
        }

        public string TimeZoneAsString
        {
            get;
            set;
        }

        public TimePeriod()
        {

        }

        public TimePeriod(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public string FormattedStartDate
        {
            get
            {
                return Start.ToDateFormattedString();
            }
        }

        public string FormattedTimeRange
        {
            get
            {
                return Start.ToTimeRangeFormattedString(End);
            }
        }
    }
}
