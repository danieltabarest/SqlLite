namespace System
{
    public static class DateExtensions
    {
        private static string shortDateFormat = "MMM d";
        private static string longDateFormat = "MMM d, yyyy";
        private static string timeFormat = "h:mm";
        private static string ampmFormat = "tt";

        public static string ToFormattedString(this DateTime date)
        {
            return $"{date.ToString(longDateFormat)} at {date.ToString(timeFormat)}{date.ToString(ampmFormat).ToLower()}";
        }

        public static string ToMonthDayRangeFormattedString(this DateTime start, DateTime end)
        {
            var startDate = start.ToString(shortDateFormat);
            var startTime = $"{start.ToString(timeFormat)}{start.ToString(ampmFormat).ToLower()}";

			var endDate = end.ToString(shortDateFormat);
            var endTime = $"{end.ToString(timeFormat)}{end.ToString(ampmFormat).ToLower()}";

            if (startDate == endDate)
                return $"{startDate}, {startTime} - {endTime}";

            return $"{startDate}, {startTime} - {endDate}, {endTime}";
        }


        public static string ToDateFormattedString(this DateTime date)
        {
            return date.ToString(longDateFormat);
        }

        public static string ToTimeRangeFormattedString(this DateTime start, DateTime end)
        {
            var startTime = $"{start.ToString(timeFormat)}{start.ToString(ampmFormat).ToLower()}";
            var endTime = $"{end.ToString(timeFormat)}{end.ToString(ampmFormat).ToLower()}";

            return $"{startTime} - {endTime}";
        }

        public static string ToDurationFormattedString(this DateTime start, DateTime end)
        {
            var difference = end - start;

            if (difference == TimeSpan.Zero)
                return string.Empty;

            var hours = difference.Hours;
            var minutes = difference.Minutes;
            var seconds = difference.Seconds;

            if (hours != 0 && minutes == 0 && seconds == 0)
                return $"{hours} hr";
            
            else if (hours != 0 && minutes > 0 && seconds == 0)
                return $"{hours} hr {minutes} mins";
            
			else if (hours != 0 && seconds > 0 && minutes == 0)
                return $"{hours} hr {seconds} secs";

			else if (hours == 0 && minutes != 0 && seconds != 0)
                return $"{minutes} mins {seconds} secs";
            
			else if (hours == 0 && minutes != 0 && seconds == 0)
                return $"{minutes} mins";
            
			else if (hours == 0 && minutes == 0 && seconds != 0)
                return $"{seconds} secs";

            return $"{hours} hr {minutes} mins {seconds} secs";
        }

        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime)
        {
            var universalTime = dateTime.ToUniversalTime();

            if (universalTime <= DateTimeOffset.MinValue.UtcDateTime)
                return DateTimeOffset.MinValue;

            if (universalTime >= DateTimeOffset.MaxValue.UtcDateTime)
                return DateTimeOffset.MaxValue;

            return new DateTimeOffset(dateTime);
        }
    }
}
