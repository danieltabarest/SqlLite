using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class AssignmentMapper : Base.BaseDataMapper, IDataMapper<Definition.Models.Assignment, Assignment>
    {
        public AssignmentMapper(IUserAccountRepository userAccountRepository)
            : base(userAccountRepository)
        {
        }

        public Assignment ToData(Definition.Models.Assignment domain)
        {
            var userId = GetUserId();

            return new Assignment
            {
                Id = domain.Id,
                UserId = userId,
                CourseId = domain.CourseId,
                Name = domain.Name,
                DueDate = domain.DueDate
            };
        }

        public Definition.Models.Assignment ToDomain(Assignment data)
        {
            return new Definition.Models.Assignment
            {
                Id = data.Id,
                CourseId = data.CourseId,
                Name = data.Name,
                DueDate = data.DueDate
            };
        }
    }
}
