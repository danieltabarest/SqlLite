using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class SyllabusDto : Base.JsonObject<Syllabus>
    {
        
        public string Url
        {
            get;
            set;
        }

        public string Crn
        {
            get;
            set;
        }

        public string Course
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public bool Endorsed
        {
            get;
            set;
        }

        public override Syllabus ToDomainModel()
        {
            return new Syllabus(Course, GenerateTitle(), Url)
            {
                Endorsed = Endorsed
            };
        }

        private string GenerateTitle()
        {
            var title = "Syllabus";

            if (string.IsNullOrWhiteSpace(Course) || string.IsNullOrWhiteSpace(Subject))
                return title;

            return $"{title} - {Subject} {Course}";
        }
    }
}
