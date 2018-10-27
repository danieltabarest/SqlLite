using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class GradeMapper : Base.BaseDataMapper, IDataMapper<Definition.Models.Grade, Grade>
    {
        public GradeMapper(IUserAccountRepository userAccountRepository)
            : base(userAccountRepository)
        {
        }

        public Grade ToData(Definition.Models.Grade domain)
        {
            var userId = GetUserId();

            return new Grade
            {
                Id = domain.Id,
                UserId = userId,
                CourseId = domain.CourseId,
                ContentId = domain.ContentId,
                Title = domain.Title,
                ActualGrade = domain.ActualGrade,
                PossibleGrade = domain.PossibleGrade,
                IsCompleted = domain.IsCompleted,
                IsUnread = domain.IsUnread,
                FirstRead = domain.FirstRead,
                LastAssignmentSubmission = domain.LastAssignmentSubmission
            };
        }

        public Definition.Models.Grade ToDomain(Grade data)
        {
            return new Definition.Models.Grade(
                data.Id, 
                data.CourseId, 
                data.ContentId, 
                data.Title, 
                data.ActualGrade, 
                data.PossibleGrade, 
                data.IsCompleted
            )
            {
                LastAssignmentSubmission = data.LastAssignmentSubmission,
                IsUnread = data.IsUnread,
                FirstRead = data.FirstRead
            };
        }
    }
}
