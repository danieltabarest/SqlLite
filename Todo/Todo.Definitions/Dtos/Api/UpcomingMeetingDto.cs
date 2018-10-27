using System.Collections.Generic;
using System.Linq;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class UpcomingMeetingDto : Base.JsonObject<UpcomingMeeting>
    {
  
        public string Description
        {
            get;
            set;
        }


        public int EventId
        {
            get;
            set;
        }

        public string ManagedUrl
        {
            get;
            set;
        }

        public IEnumerable<OrganizerDto> Organizers
        {
            get;
            set;
        }

        public string RegistrationUrl
        {
            get;
            set;
        }

        public string StartTraining
        {
            get;
            set;
        }

        public IEnumerable<TimePeriodDto> Times
        {
            get;
            set;
        }

        public string TimeZone
        {
            get;
            set;
        }

        public string Title
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

        public string Type
        {
            get;
            set;
        }


        public override UpcomingMeeting ToDomainModel()
        {
            return new UpcomingMeeting
            {
                Title = Title,
                Description = Description,
                RegistrationUrl = RegistrationUrl,
                Type = Type,
                Organizers = BuildOrganizers(),
                TrainingId = TrainingId,
                TrainingKey = TrainingKey,
                TrainingUrl = StartTraining,
                ManagedUrl = ManagedUrl,
                Sessions = BuildSessions()
            };
        }

        private IEnumerable<TimePeriod> BuildSessions()
        {
            return Times.Select(t => t.ToDomainModel());
        }

        private IEnumerable<Staff> BuildOrganizers()
        {
            return Organizers.Select(o => o.ToDomainModel());
        }
    }
}
