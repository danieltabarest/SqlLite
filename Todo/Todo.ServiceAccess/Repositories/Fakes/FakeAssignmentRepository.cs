using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeAssignmentRepository : IAssignmentRepository
    {
        private readonly IEnumerable<Assignment> _assignments;

        public FakeAssignmentRepository()
        {
            _assignments = new List<Assignment>
            {
                new Assignment{
                    Id = "_1116961_1",
                    CourseId = "_158274_1",
                    Name = "Medical Informatics_Module 1 Quiz",
                    DueDate = DateTime.Now.AddDays(-4),
                },
				new Assignment{
					Id = "_1116962_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 2 Quiz",
                    DueDate = DateTime.Now.AddDays(-3),
				},
				new Assignment{
					Id = "_1116963_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 3 Quiz",
                    DueDate = DateTime.Now.AddDays(3),
				},
				new Assignment{
					Id = "_1116964_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 4 Quiz",
					DueDate = DateTime.Now.AddDays(5),
				},
				new Assignment{
					Id = "_1116965_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 5 Quiz",
                    DueDate = DateTime.Now.AddDays(8),
				},
				new Assignment{
					Id = "_1116966_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 6 Quiz",
                    DueDate = DateTime.Now.AddDays(9),
				},
				new Assignment{
					Id = "_1116967_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 7 Quiz",
                    DueDate = DateTime.Now.AddDays(10),
				},
				new Assignment{
					Id = "_1116968_1",
					CourseId = "_158274_1",
					Name = "Mid-Term Project",
                    DueDate = DateTime.Now.AddDays(15),
				},
				new Assignment{
					Id = "_1116969_1",
					CourseId = "_158274_1",
					Name = "Course Project",
                    DueDate = DateTime.Now.AddDays(17),
				},
				new Assignment{
					Id = "_1116971_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 8 Quiz",
					DueDate = DateTime.Now.AddDays(20),
				},
				new Assignment{
					Id = "_1116972_1",
					CourseId = "_158274_1",
					Name = "Medical Informatics_Module 9 Quiz",
					DueDate = DateTime.Now.AddDays(30),
				},
				new Assignment{
					Id = "_1116991_1",
					CourseId = "_158274_2",
					Name = "Fun Course Module 1 Quiz",
					DueDate = DateTime.Now.AddDays(2),
				},
				new Assignment{
					Id = "_1116992_1",
					CourseId = "_158274_2",
					Name = "Fun Course Module 2 Quiz",
					DueDate = DateTime.Now.AddDays(1),
				},
				new Assignment{
					Id = "_11169963_1",
					CourseId = "_158274_2",
					Name = "Good stuff Module 3 Quiz",
					DueDate = DateTime.Now.AddDays(4),
				},
            };
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync(string courseId)
        {
            await Task.Delay(1000);
            return _assignments.Where( a => a.CourseId == "_158274_1").ToList();
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync()
        {
			await Task.Delay(1000);
			return _assignments;
        }
    }
}
