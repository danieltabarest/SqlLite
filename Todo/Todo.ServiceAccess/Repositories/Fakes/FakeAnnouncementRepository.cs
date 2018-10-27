using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeAnnouncementRepository : IAnnouncementRepository
	{
		private readonly IEnumerable<Announcement> _announcements;

		public FakeAnnouncementRepository()
		{
			_announcements = new List<Announcement>
			{
				new Announcement("_607186_1", "This is a test announcement", DateTime.Now.AddDays(-2), AnnouncementType.Course)
				{
					CourseId = "_158274_1",
					Body = "The following test has been made available in Assessments (Quizzes): Quiz 1 -  Chapters 1 & 2 - Due before midnight (Eastern Time) on Sunday, 12/11/16."
				},

				new Announcement("_607186_2", "Skype", DateTime.Now.AddDays(-2), AnnouncementType.Course)
				{
					CourseId = "_158274_1",
					Body = "<font color=\\\"#6633cc\\\" size=\\\"4\\\">\u00a0\\nGreetings! Look forward to seeing everyone on Skype on August 2, 2012 at noon!</font>"
				},
				new Announcement("_607186_3", "Healthy People 2020 Lecture", DateTime.Now.AddDays(-2), AnnouncementType.Course)
				{
					CourseId = "_158274_1",
					Body = "<font color=\\\"#33cc00\\\">\\n<strong><font size=\\\"4\\\">Hello Residents, see you tomorrow at 12pm in Blackboard Elluminate for the session!</font></strong></font>"
				},
				new Announcement("_607186_4", "Test Announcement For Mobile", DateTime.Now.AddDays(-2), AnnouncementType.Course)
				{
					CourseId = "_158274_1",
					Body = "<h3>Strategic Support Services will be closed Saturday, December 24, 2016 through Monday, January 2, 2017</h3>\\n<p style=\\\"margin-bottom: 7.5pt;\\\">As you prepare for the upcoming Winter semester, we encourage you to review your Blackboard courses before NSU’s winter closure. IZone asks that you <i>submit any requests by Monday, December 19, 2016</i> to ensure that they are completed prior to student access.</p>\\n<p style=\\\"margin-bottom: 7.5pt;\\\"><em><b>No requests will be processed during the Winter break</b></em><strong>.</strong> This includes course copies, course content issues, exam uploads, etc. All requests submitted on December 24th through January 2nd will be addressed when NSU resumes normal operating schedule on January 3, 2017.</p>\\n<p style=\\\"margin-bottom: 7.5pt;\\\">Here are some things to consider as you prepare your Blackboard courses:</p>\\n<ul>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/beginning-of-semester-checklist.html\\\" title=\\\"Beginning of Semester Checklist\\\">Beginning of Semester Checklist</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/making-requests-to-izone-for-course-design-support.html\\\" title=\\\"What to Include When Making Requests to the IZone \\\">What to Include When Making Requests to the IZone</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/blackboard-course-menu-and-tool-availability.html\\\" title=\\\"Course menu and tool availability\\\">Course Menu and Tool Availability</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/blackboard-going-beyond-the-basics.html\\\" title=\\\"Blackboard: Going Beyond the Basics\\\">Blackboard: Going Beyond the Basics</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/creating-and-copying-rubrics.html\\\" title=\\\"Creating and Copying Rubrics\\\">Creating and Copying Rubrics</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/goto-training-resources.html\\\" title=\\\"GoTo Training Resources\\\">GoTo Training Resources</a></li>\\n</ul>\\n<p><br /> </p>"
				},
				new Announcement("_607186_5", "This is a test system announcement for the fake data repository", DateTime.Now.AddDays(-20), AnnouncementType.System)
				{
					Body = "The following test has been made available in Assessments (Quizzes): Quiz 1 -  Chapters 1 & 2 - Due before midnight (Eastern Time) on Sunday, 12/11/16."
				},
				new Announcement("_607186_6", "Strategic Support Services Winter Closure", DateTime.Now.AddDays(-20), AnnouncementType.System)
				{
					Body = "<h3>Strategic Support Services will be closed Saturday, December 24, 2016 through Monday, January 2, 2017</h3>\\n<p style=\\\"margin-bottom: 7.5pt;\\\">As you prepare for the upcoming Winter semester, we encourage you to review your Blackboard courses before NSU’s winter closure. IZone asks that you <i>submit any requests by Monday, December 19, 2016</i> to ensure that they are completed prior to student access.</p>\\n<p style=\\\"margin-bottom: 7.5pt;\\\"><em><b>No requests will be processed during the Winter break</b></em><strong>.</strong> This includes course copies, course content issues, exam uploads, etc. All requests submitted on December 24th through January 2nd will be addressed when NSU resumes normal operating schedule on January 3, 2017.</p>\\n<p style=\\\"margin-bottom: 7.5pt;\\\">Here are some things to consider as you prepare your Blackboard courses:</p>\\n<ul>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/beginning-of-semester-checklist.html\\\" title=\\\"Beginning of Semester Checklist\\\">Beginning of Semester Checklist</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/making-requests-to-izone-for-course-design-support.html\\\" title=\\\"What to Include When Making Requests to the IZone \\\">What to Include When Making Requests to the IZone</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/blackboard-course-menu-and-tool-availability.html\\\" title=\\\"Course menu and tool availability\\\">Course Menu and Tool Availability</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/blackboard-going-beyond-the-basics.html\\\" title=\\\"Blackboard: Going Beyond the Basics\\\">Blackboard: Going Beyond the Basics</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/creating-and-copying-rubrics.html\\\" title=\\\"Creating and Copying Rubrics\\\">Creating and Copying Rubrics</a></li>\\n<li><a href=\\\"https://www.nova.edu/portal/oiit/support/sss/faculty/blackboard/tech-talk/2015/goto-training-resources.html\\\" title=\\\"GoTo Training Resources\\\">GoTo Training Resources</a></li>\\n</ul>\\n<p><br /> </p>"
				},
				new Announcement("_607186_7", "Healthy Peeps 2030 Lecture", DateTime.Now.AddDays(-2), AnnouncementType.Course)
				{
					CourseId = "_158274_7",
					Body = "<font color=\\\"#33cc00\\\">\\n<strong><font size=\\\"4\\\">Hello Residents, see you tomorrow at 12pm in Blackboard Elluminate for the session!</font></strong></font>"
				},
				new Announcement("_607186_8", "Healthy Peeps 2030 Lecture", DateTime.Now.AddDays(-2), AnnouncementType.Course)
				{
					CourseId = "_158274_7",
					Body = "<font color=\\\"#33cc00\\\">\\n<strong><font size=\\\"4\\\">Hello Residents, see you tomorrow at 12pm in Blackboard Elluminate for the session!</font></strong></font>"
				},
			};
		}

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
        {
            await Task.Delay(1000);
            return _announcements.ToList();
        }

        public async Task<IEnumerable<Announcement>> GetCourseAnnouncementsAsync(string courseId)
		{
			await Task.Delay(1000);
			return _announcements.Where(a => a.Type == AnnouncementType.Course).ToList();
		}

        public async Task<IEnumerable<Announcement>> GetCourseAnnouncementsAsync()
        {
			await Task.Delay(1000);
			return _announcements.Where(a => a.Type == AnnouncementType.Course).ToList();
        }

        public async Task<IEnumerable<Announcement>> GetSystemAnnouncementsAsync()
		{
			await Task.Delay(1000);
			return _announcements.Where(a => a.Type == AnnouncementType.System);
		}
	}
}
