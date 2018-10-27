using System;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class GradeDto : Base.JsonObject<Grade>
    {
        
        public string ColumnId
        {
            get;
            set;
        }

        public string CourseId
        {
            get;
            set;
        }

        public string ColumnContentId
        {
            get;
            set;
        }

        public string ColumnNameDisplay
        {
            get;
            set;
        }

        public string ActualGrade
        {
            get;
            set;
        }

        public string PossibleGrade
        {
            get;
            set;
        }

        public bool Status
        {
            get;
            set;
        }

        public string LatestAttemptDate
        {
            get;
            set;
        }

        public override Grade ToDomainModel()
        {
            return new Grade(ColumnId,
                             CourseId,
                             ColumnContentId,
                             ColumnNameDisplay,
                             ConvertGradePoint(ActualGrade),
                             ConvertGradePoint(PossibleGrade),
                             Status)
            {
                LastAssignmentSubmission = DateTime.Parse(LatestAttemptDate)
            };
        }

        private double ConvertGradePoint(string pointText)
        {
            double convertedPoint;

            try
            {
                convertedPoint = Convert.ToDouble(pointText);    
            }
			catch (Exception)
			{
                convertedPoint = 0.0;
			}

            return convertedPoint;
        }
    }
}
