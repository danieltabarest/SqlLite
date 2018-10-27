using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeMeetingRepository : IMeetingRepository
    {
        private readonly IEnumerable<UpcomingMeeting> _meeting;
        private readonly IEnumerable<RecordedMeeting> _recording;

        public FakeMeetingRepository()
        {
            var previousStart = DateTime.Today.AddMonths(-4).AddHours(5).AddMinutes(10);
            var previousEnd = DateTime.Today.AddDays(2).AddHours(5).AddMinutes(10);
            var Start = DateTime.Today.AddHours(5).AddMinutes(10);
            var End = DateTime.Today.AddHours(5).AddMinutes(20);

            _recording = new List<RecordedMeeting>
            {
                new RecordedMeeting()
                {
                    CourseId = "_302130_1",
                    Description = "Gototraining Meeting Title",
                    Started = End,
                    Ended = Start,
                    Title = "RecordedName",
                    RecordingId = 21,
                    RegistrationUrl = "URL"

                },
                new RecordedMeeting()
                {
                    CourseId = "_302130_1",
                    Description = "Gototraining Meeting Title",
                    Ended = End.AddHours(4),
                    Started = Start,
                    Title = "RecordedName",
                    RecordingId = 21,
                    RegistrationUrl = "URL"

                }, new RecordedMeeting()
                {
                    CourseId = "_302130_1",
                    Description = "Gototraining Meeting Title",
                    Ended = End.AddMinutes(35),
                    Started = Start,
                    Title = "RecordedName",
                    RecordingId = 21,
                    RegistrationUrl = "URL"

                }, new RecordedMeeting()
                {
                    CourseId = "_302130_1",
                    Description = "Gototraining Meeting Title",
                    Ended = End.AddSeconds(20),
                    Started = Start,
                    Title = "RecordedName",
                    RecordingId = 21,
                    RegistrationUrl = "URL"

                }, new RecordedMeeting()
                {
                    CourseId = "_302130_1",
                    Description = "Gototraining Meeting Title",
                    Ended = End.AddHours(2),
                    Started = Start,
                    Title = "RecordedName",
                    RecordingId = 21,
                    RegistrationUrl = "URL"

                }
            };

            _meeting = new List<UpcomingMeeting>
            {
                new UpcomingMeeting
                {
                    CourseId = "_302130_1",
                    EventId = 12333456,
                    Title = "Gototraining Meeting Title",
                    Sessions = new List<TimePeriod>
                    {
                        new TimePeriod(Start, End),
                        new TimePeriod(Start.AddDays(1), End.AddDays(1)),
						new TimePeriod(Start, End),
						new TimePeriod(Start.AddDays(1), End.AddDays(1))
					},
                    Organizers = new List<Staff>
                    {
                        new Staff
                        {
                            Name = "Paul Bunyon",
                            EmailAddress = "paul@nova.edu"
                        },
                        new Staff
                        {
                            Name = "Mike Wiznaski",
                            EmailAddress = "mike@nova.edu"
                        },
						new Staff
						{
							Name = "Paul Bunyon",
							EmailAddress = "paul@nova.edu"
						},
						new Staff
						{
							Name = "Mike Wiznaski",
							EmailAddress = "mike@nova.edu"
						}
                    }
                },

				new UpcomingMeeting
                {
					CourseId = "_302130_1",
					EventId = 12333426,
                    Title = "Gototraining Meeting Title 2",
					Sessions = new List<TimePeriod>
					{
                        new TimePeriod(Start.AddDays(5), End.AddDays(5).AddHours(2).AddMinutes(20))
					},
					Organizers = new List<Staff>
					{
						new Staff
                        {
							Name = "Paul Bard",
							EmailAddress = "paulbard@nova.edu"
						}
					}
				},

            };
        }



        public async Task<IEnumerable<UpcomingMeeting>> GetUpcomingMeetingsForCourseAsync(MeetingRequestDto meetingRequest)
        {
            await Task.Delay(1000);
            return _meeting.ToList();
        }


        public async Task<IEnumerable<RecordedMeeting>> GetRecordedMeetingsForCourseAsync(MeetingRequestDto meetingRequest)
        {
            await Task.Delay(1000);
            return _recording.ToList();
        }
    }
}
