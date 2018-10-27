using System;
using Todo.LocalData.Models;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class AnnouncementMapper : Base.BaseDataMapper, IDataMapper<Definition.Models.Announcement, Announcement>
    {
        public AnnouncementMapper(IUserAccountRepository userAccountRepository)
            : base(userAccountRepository)
        {
        }

        public Announcement ToData(Definition.Models.Announcement domain)
        {
            var userId = GetUserId();

            return new Announcement
            {
                Id = domain.Id,
                UserId = userId,
                CourseId = domain.CourseId,
                Title = domain.Title,
                Author = domain.Author,
                CreationDate = domain.CreationDate,
                IsUnread = domain.IsUnread,
                Type = domain.Type.ToString(),
                Body = domain.Body,
                FirstRead = domain.FirstRead
            };
        }

        public Definition.Models.Announcement ToDomain(Announcement data)
        {
            return new Definition.Models.Announcement
            {
                Id = data.Id,
                CourseId = data.CourseId,
                Title = data.Title,
                Author = data.Author,
                CreationDate = data.CreationDate,
                IsUnread = data.IsUnread,
                FirstRead = data.FirstRead,
                Type = ConvertToAnnouncementType(data.Type),
                Body = data.Body ?? string.Empty
            };
        }

        private AnnouncementType ConvertToAnnouncementType(string announcementType)
        {
            try
            {
                return (AnnouncementType)Enum.Parse(typeof(AnnouncementType), announcementType);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid announcement type.", ex);
            }
        }
    }
}
