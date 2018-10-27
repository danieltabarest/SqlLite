using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeContentRepository : IContentRepository
    {
        private readonly IEnumerable<Content> _content;

        public FakeContentRepository()
        {
            _content = new List<Content>
            {
                new Folder("_3115966_1", "Residency Training in Family Medicine Course", "_158274_1"),
                new Folder("_3115966_2", "CEME Psychiatry Resident Didactics", "_158274_1"),
                new Folder("_3115966_3", "Introduction to Research", "_158274_1")
                {
                    ParentId = "_3115966_1"
                },
                new File("_3115966_4", "Grant Objective and Timeline", "_158274_1", FileType.File)
                {
                    ParentId = "_3115966_3",
                    Extension = "pdf"
                },
                new File("_3115966_5", "Welcome to the Residency Training in Family Medicine Course", "_158274_1", FileType.Document)
                {
                    ParentId = "_3115966_1",
                    Body = "<div style=\\\"text-align: center; \\\">&nbsp;</div> <div><font face=\\\"book antiqua, times new roman, times, serif\\\" size=\\\"4\\\">In order for you to be able to see the content of each of the Modules listed below, you will first need to click on the corresponding Icon and respond to the question <b>&quot;</b><span style=\\\"background-color: rgb(250, 250, 250); \\\"><b>Are you ready to start your All Hazards Preparedness (Rural Medicine)/ Medical Informatics Module ?&quot;</b> .\u00a0Once\u00a0you gain access to the Module you will be able to read the Introduction/Course Mechanics for the corresponding module. \u00a0</span></font></div>"
                },
                new File("_3115966_6", "Begin CEME Psychiatry Resident Didactics Module", "_158274_1", FileType.TestLink),
                new File("_3115966_7", "The Doctor's Dilemma", "_158274_1", FileType.File)
                {
                    Extension = "pdf"
                },
                new File("_3115966_8", "Test file one", "_158274_1", FileType.File)
                {
                    ParentId = "_3115966_2",
                    Extension = "pdf"
                },
                new File("_3115966_9", "Test file two", "_158274_1", FileType.File)
                {
                    ParentId = "_3115966_2",
                    Extension = "pdf"
                },
                new File("_3115966_10", "Test file three", "_158274_1", FileType.File)
                {
                    ParentId = "_3115966_2",
                    Extension = "pdf"
                },
                new Folder("_3115966_11", "Shark Media", "_158274_1", FolderType.VideoPlaylist)
                {
                    ApplicationType = ApplicationType.Kaltura,
                    ItemCount = 3
                },
                new Folder("_3115966_12", "GoTo Training", "_158274_1")
                {
                    ItemCount = 10
                }
            };
        }

        public async Task<IEnumerable<Content>> GetContentForCourseAsync(string courseId)
        {
            await Task.Delay(1000);
            return _content.Where(c => c.ParentId == null).ToList();
        }

        public async Task<IEnumerable<Content>> GetContentInFolderForCourseAsync(string courseId, string folderId)
        {
            await Task.Delay(1000);
            return _content.Where(c => c.ParentId == folderId).ToList();
        }

        public Task<byte[]> GetDocToPdfFileAsync(Uri fileUrl, string courseId, string contentId, string fileExtension)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetFileAsync(Uri fileUrl, string base64EncodedCredentials)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Syllabus>> GetSyllabiForCourseAsync(string crn, string termCode, bool isCrosslistedCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Video>> GetVideoForCourseAsync(string crn, int thumbnailHeight, int thumbnailWidth)
        {
            await Task.Delay(1000);
            return new List<Video>
            {
                new Video
                { 
                    CreatedAt = DateTime.Now ,
                    Name = "Fall 2017 Law 0662 E- Legal Reserach and Writing I-Baxter" ,
                    Duration ="0:00049 of : 60:00" ,
                    Description ="Fall 2017",
                    StreamUri = new Uri("http://cdnbakmi.kaltura.com/p/1971581/sp/197158100/playManifest/entryId/1_5fwa7f5d/flavorId/1_ss9ma9st/format/url/protocol/http/a.mp4"),
                    ThumbnailUri = new Uri("https://cdnapisec.kaltura.com//p/1971581/thumbnail/entry_id/1_gfhk47p2/width/100/height/100/type/3/quality/100")
                },
                new Video
                { 
                    CreatedAt = DateTime.Now ,
                    Name = "Fall 2017 Law 0662 E- Legal Reserach and Writing I-Baxter" ,
                    Duration ="0:00049 of : 60:00" ,
                    Description ="Fall 2017",
                    StreamUri = new Uri("http://cfvod.kaltura.com/pd/p/1831271/sp/183127100/serveFlavor/entryId/1_ng282arr/v/11/flavorId/1_8a7wdwzi/name/a.mp4"),
                    ThumbnailUri = new Uri("https://cdnapisec.kaltura.com//p/1971581/thumbnail/entry_id/1_gfhk47p2/width/100/height/100/type/3/quality/100")

                },
                new Video
                { 
                    CreatedAt = DateTime.Now ,
                    Name = "Fall 2017 Law 0662 E- Legal Reserach and Writing I-Baxter" ,
                    Duration ="0:00049 of : 60:00" ,
                    Description ="Fall 2017",
                    ThumbnailUri = new Uri("https://cdnapisec.kaltura.com//p/1971581/thumbnail/entry_id/1_gfhk47p2/width/100/height/100/type/3/quality/100"),
                    StreamUri = new Uri("http://cdnbakmi.kaltura.com/p/1971581/sp/197158100/playManifest/entryId/1_5fwa7f5d/flavorId/1_ss9ma9st/format/url/protocol/http/a.mp4"),
                },
                         
                new Video
                { 
                    CreatedAt = DateTime.Now ,
                    Name = "Fall 2017 Law 0662 E- Legal Reserach and Writing I-Baxter" ,
                    Duration ="0:00049 of : 60:00" ,
                    Description ="Fall 2017",
                    StreamUri = new Uri("http://cfvod.kaltura.com/pd/p/1831271/sp/183127100/serveFlavor/entryId/1_ng282arr/v/11/flavorId/1_8a7wdwzi/name/a.mp4"),
                    ThumbnailUri = new Uri("https://cdnapisec.kaltura.com//p/1971581/thumbnail/entry_id/1_gfhk47p2/width/100/height/100/type/3/quality/100"),
                },
                            
                new Video
                { 
                    CreatedAt = DateTime.Now ,
                    Name = "Fall 2017 Law 0662 E- Legal Reserach and Writing I-Baxter" ,
                    Duration ="0:00049 of : 60:00" ,
                    ThumbnailUri = new Uri("https://cdnapisec.kaltura.com//p/1971581/thumbnail/entry_id/1_gfhk47p2/width/100/height/100/type/3/quality/100"),
                    Description ="Fall 2017",
                    StreamUri = new Uri("http://cdnbakmi.kaltura.com/p/1971581/sp/197158100/playManifest/entryId/1_5fwa7f5d/flavorId/1_ss9ma9st/format/url/protocol/http/a.mp4")
                }
            };
        }
    }
}
