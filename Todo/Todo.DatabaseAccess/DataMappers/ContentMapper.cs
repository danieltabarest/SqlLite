using System;
using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class ContentMapper : Base.BaseDataMapper, IDataMapper<Definition.Models.Content, Content>
    {
        public ContentMapper(IUserAccountRepository userAccountRepository)
            : base(userAccountRepository)
        {
        }

        public Content ToData(Definition.Models.Content domain)
        {
            var userId = GetUserId();

            return new Content
            {
                UserId = userId,
                Id = domain.Id,
                ParentId = domain.ParentId,
                Title = domain.Title,
                CourseId = domain.CourseId,
                ContentType = RetrieveContentType(domain)
            };
        }

        public Definition.Models.Content ToDomain(Content data)
        {
            throw new NotSupportedException();
        }

        private string RetrieveContentType(Definition.Models.Content content)
        {
            return content.GetType().Name;
        }
    }
}
