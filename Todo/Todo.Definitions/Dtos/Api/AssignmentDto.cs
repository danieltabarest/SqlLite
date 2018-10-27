using System;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class AssignmentDto : Base.JsonObject<Assignment>
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

        public string ColumnName
        {
            get;
            set;
        }

        public string ColumnId
        {
            get;
            set;
        }

        public string ColumnDueDate
        {
            get;
            set;
        }

        public override Assignment ToDomainModel()
        {
            return new Assignment
            {
                Id = Id ?? ColumnId,
                CourseId = CourseId,
                Name = ColumnName,
                DueDate = DateTime.Parse(ColumnDueDate)
            };
        }
    }
}
