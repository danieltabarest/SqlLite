using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IContentService
    {
        Task<IEnumerable<Content>> ContentForCourseAsync(Course course);

        Task<IEnumerable<Content>> ContentInFolderForCourseAsync(Course course, Folder folder);
        
        Task<Stream> FileStreamAsync(Uri fileUrl);

        Task<Stream> PdfFileStreamAsync(Uri fileUrl, string courseId, string contentId, string fileExtension);
    }
}
