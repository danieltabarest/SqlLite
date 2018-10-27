using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeGradesRepository : IGradeRepository
    {
        private readonly IEnumerable<Grade> _grades;

        public FakeGradesRepository()
        {
            _grades = new List<Grade>
            {
                new Grade("1", "_158274_1", "_3116001_1", "Medical Informatics_Module 1 Quiz", 3.0, 10.0, true)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("2", "_158274_1", "_3116001_1", "Medical Informatics_Module 2 Quiz", 10.0, 10.0, true)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("3", "_158274_1", "_3116001_1", "Medical Informatics_Module 3 Quiz", 9.0, 10.0, true)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("4", "_158274_1", "_3116001_1", "Medical Informatics_Module 4 Quiz", 8.0, 10.0, true)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("5", "_158274_1", "_3116001_1", "Medical Informatics_Module 5 Quiz", 6.0, 10.0, true)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("6", "_158274_1", "_3116001_1", "Medical Informatics_Module 6 Quiz", 0.0, 10.0, false)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("7", "_158274_1", "_3116001_1", "Medical Informatics_Module 7 Quiz", 0.0, 10.0, false)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("8", "_158274_1", "_3116001_1", "Medical Informatics_Module 8 Quiz", 0.0, 10.0, false)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
				new Grade("9", "_158274_4", "_3116001_1", "Project 1 Quiz", 9.0, 10.0, true)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                },
                new Grade("10", "_158274_4", "_3116001_1", "Project 2 Quiz", 8.5, 10.0, true)
                {
                    LastAssignmentSubmission = DateTime.Now.AddDays(-1)
                }
            };
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync(string courseId)
        {
            await Task.Delay(1000);
            return _grades.Where( g => g.CourseId == "_158274_1").ToList();
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
			await Task.Delay(1000);
			return _grades;
        }
    }
}
