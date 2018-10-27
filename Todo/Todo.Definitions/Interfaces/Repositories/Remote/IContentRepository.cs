using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Interfaces.Repositories.Remote
{
    public interface IContentRepository
    {
        Task<IEnumerable<Content>> GetContentForCourseAsync(string courseId);

        Task<IEnumerable<Content>> GetContentInFolderForCourseAsync(string courseId, string folderId);

        Task<byte[]> GetFileAsync(Uri fileUrl, string base64EncodedCredentials);

        Task<byte[]> GetDocToPdfFileAsync(Uri fileUrl, string courseId, string contentId, string fileExtension);
    }
}
