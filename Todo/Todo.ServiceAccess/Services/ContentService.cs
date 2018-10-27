using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IAuthenticationService _authenticationService;

        public ContentService(IContentRepository contentRepository, IAuthenticationService authenticationService)
        {
            _contentRepository = contentRepository;
            _authenticationService = authenticationService;
        }

        public async Task<IEnumerable<Content>> ContentForCourseAsync(Course course)
        {
            return await _contentRepository.GetContentForCourseAsync(course.Id);
        }

        public async Task<IEnumerable<Content>> ContentInFolderForCourseAsync(Course course, Folder folder)
        {
            return await _contentRepository.GetContentInFolderForCourseAsync(course.Id, folder.Id);
        }

        public async Task<Stream> FileStreamAsync(Uri fileUrl)
        {
            var pdfAsBytes = await _contentRepository.GetFileAsync(fileUrl, _authenticationService.GetEncodedCredentials());
            return new MemoryStream(pdfAsBytes);
        }

        public async Task<Stream> PdfFileStreamAsync(Uri fileUrl, string courseId, string contentId, string fileExtension)
        {
            var pdfAsBytes = await _contentRepository.GetDocToPdfFileAsync(fileUrl, courseId, contentId, fileExtension);
            return new MemoryStream(pdfAsBytes);
        }
    }
}
