using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;
using NsuGo.Definition.Utilities;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeCourseRepository : ICourseRepository
	{
		private readonly List<Course> _courses;
		public FakeCourseRepository()
		{
			_courses = Courses();
		}

		public async Task<Course> GetCourseAsync(string courseId)
		{
			await Task.Delay(1000);
			return _courses.SingleOrDefault(c => c.Id == courseId);
		}

        public Task<IEnumerable<Course>> GetCrosslistedCoursesAsync(string groupCrn, string termCode)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetCourseNameAsync(string courseId)
        {
            var course = await GetCourseAsync(courseId);
            return course.Name;
        }

        public async Task<IEnumerable<Course>> GetCurrentCoursesAsync()
		{
			await Task.Delay(1000);
			return _courses;
		}

		private List<Course> Courses()
		{
			var previousSemesterStart = DateTime.Today.AddMonths(-4);
			var previousSemesterEnd = DateTime.Today.AddDays(2);

			var semesterStart = DateTime.Today.AddDays(-3);
			var semesterEnd = DateTime.Today.AddMonths(4);

			return new List<Course> {
                new Course("_158274_1", "Analysis of Algorithms", semesterStart, semesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name = "Professor John Doe, Ph.D." }},
					Term = new Term {
						Code = "201730",
						Description = "Winter 2017",
						Status = TermStatus.current,
					}
				},
                new Course("_158274_2", "Advanced OOP using Java", semesterStart, semesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Professor Sean Thorpe, Ph.D"} },
					Term = new Term {
						Code = "201730",
						Description = "Winter 2017",
						Status = TermStatus.current
					}
				},
                new Course("_158274_3", "Testing Integration 10316", semesterStart, semesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Professor Peter Lui, Ph.D"} },
					Term = new Term {
						Code = "201730",
						Description = "Winter 2017",
						Status = TermStatus.current
					}
				},
                new Course("_158274_4", "Advanced Operating Systems", semesterStart, semesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Professor Simon Simco, Ph.d"} },
					Term = new Term {
						Code = "201730",
						Description = "Winter 2017",
						Status = TermStatus.current
					}
				},
                new Course("_158274_5", "Data Structures using C", semesterStart, semesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Professor Mike Sanders, Ph.D."} },
					Term = new Term {
						Code = "201720",
						Description = "Fall 2016",
						Status = TermStatus.previous
					}
				},
                new Course("_158274_6", "Database Management Systems", semesterStart, semesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Professor Tony West, Ph.D"} },
					Term = new Term {
						Code = "201720",
						Description = "Fall 2016",
						Status = TermStatus.previous
					}
				},
                new Course("_158274_7", "Understanding Oracle 4583", previousSemesterStart, previousSemesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Professor Dave Sutherland, Ph.D"} },
					Term = new Term {
						Code = "201720",
						Description = "Fall 2016",
						Status = TermStatus.previous
					}
				},
                new Course("_158274_8", "Introduction to Development Operation Theory", previousSemesterStart, previousSemesterEnd, CourseType.AcademicCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Professor Theodore Smith, Ph.d"} },
					Term = new Term {
						Code = "201720",
						Description = "Fall 2016",
						Status = TermStatus.previous
					}
				},
                new Course("_158274_9", "Professional Ethics", semesterStart, semesterEnd, CourseType.TrainingCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Joe Hicks"} },
				},
                new Course("_158274_10", "Agile using Scrum", semesterStart, semesterEnd, CourseType.TrainingCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Martin Henry"} },
				},
                new Course("_158274_11", "ECA 0101 Introduction to Early Childhood Education", semesterStart, semesterEnd, CourseType.TrainingCourse, false) {
                    Instructors = new List<Staff> { new Staff { Name ="Paul Loft"} },
					Term = new Term {
						Code = "201730",
						Description = "Winter 2017",
						Status = TermStatus.current
					}
				}
			};
		}
	}
}
