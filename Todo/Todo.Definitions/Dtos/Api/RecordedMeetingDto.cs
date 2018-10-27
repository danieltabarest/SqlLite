using System;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class RecordedMeetingDto : Base.JsonObject<RecordedMeeting>
    {
        public int RecordingId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string StartDate
        {
            get;
            set;
        }

        public string EndDate
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

        public override RecordedMeeting ToDomainModel()
        {
            return new RecordedMeeting
            {
                Title = Name,
                Description = Description,
                RegistrationUrl = RegistrationUrl,
                Type = Type,
                RecordingId = RecordingId,
                Started = ConvertToDate(StartDate),
                Ended = ConvertToDate(EndDate)
            };
        }

        private DateTime ConvertToDate(string date)
        {
            try
            {
                return DateTime.Parse(date);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
    }
}
