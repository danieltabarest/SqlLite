using System;
using NsuGo.Definition.Enums;

namespace NsuGo.Definition.Models
{
    public class RecordedMeeting : Meeting
    {
        public int RecordingId 
        {
            get; 
            set; 
        }

        public DateTime Started
        {
            get;
            set;
        }

        public DateTime Ended
        {
            get;
            set;
        }

        public override string DisplayIcon
        {
            get
            {
                return string.Empty;
            }
        }


        public override string DatePeriod
        {
            get
            {
                return $"Recorded on: {Started.ToDateFormattedString()}";
            }
        }

        public override string Duration
        {
            get
            {
                return Started.ToDurationFormattedString(Ended);
            }
        }

        public override MeetingType MeetingType => MeetingType.Recorded;
    }
}
