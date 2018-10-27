using System;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class AnnouncementDto : Base.JsonObject<Announcement>
    {
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

        public string Title
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string RestrictionStartDate
        {
            get;
            set;
        }

        public override Announcement ToDomainModel()
        {
            return new Announcement(Id, Title, DateTime.Parse(RestrictionStartDate), TypeConverter(Type))
            {
                Body = Body,
                CourseId = CourseId,
                IsUnread = true
            };
        }

        private AnnouncementType TypeConverter(string type)
        {
            if (type == "blackboard.data.announcement.Announcement$Type:COURSE")
                return AnnouncementType.Course;
            else
                return AnnouncementType.System;
        }
    }
}
