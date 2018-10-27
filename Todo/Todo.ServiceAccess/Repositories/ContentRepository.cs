using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Common.Helpers;
using NsuGo.Definition.Dtos.Api;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace NsuGo.ServiceAccess.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly IAPIContext _apiContext;

        public ContentRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<Content>> GetContentForCourseAsync(string courseId)
        {
            var uri = $"learning/CourseData/content/tableofcontent/withcontent?courseId={courseId}&lms={Preferences.LMS}";
            var exceptionMessage = $"There was error while attempting to get content for course with id: {courseId}";

            return await _apiContext.GetResourcesAsync<Content, ContentDto>(uri, exceptionMessage);
		}

        public async Task<IEnumerable<Content>> GetContentInFolderForCourseAsync(string courseId, string folderId)
        {
			var uri = $"learning/CourseData/content/children/course/{courseId}/content/{folderId}?lms={Preferences.LMS}";
			var exceptionMessage = $"There was error while attempting to get content for course with id: {courseId} in folder: {folderId}.";

			return await _apiContext.GetResourcesAsync<Content, ContentDto>(uri, exceptionMessage);
        }

        public async Task<byte[]> GetDocToPdfFileAsync(Uri fileUrl, string courseId, string contentId, string fileExtension)
        {
            try
            {
                var uri = $"learning/CourseData/content/aspdf?document={fileUrl}&courseId={courseId}&contentId={contentId}&fileType={fileExtension}&lms={Preferences.LMS}";
                var message = $"There was error while attempting to retrieve converted PDF for document at {fileUrl}.";

                var pdfAsText = await _apiContext.GetResourceAsync(uri, message);
                return Convert.FromBase64String(pdfAsText);
            }
			catch (InternetConnectionException)
			{
				throw;
			}
			catch (System.Net.Http.HttpRequestException ex)
			{
				if (ex.Message == "404 (Not Found)")
					throw new FileNotFoundException($"The file at {fileUrl} cannot be found.", ex);
				else
					throw new FileErrorException($"There was an error while attemping to get the bytes for the file at {fileUrl}", ex);
			}
			catch (Exception ex)
			{
				throw new DataRepositoryException($"There was an error while attempting to get the file at {fileUrl}", ex);
			}
        }

        public async Task<byte[]> GetFileAsync(Uri fileUrl, string base64EncodedCredentials)
        {
			try
			{
				using (var client = new RestClient(fileUrl))
				{
					var request = new RestRequest(Method.GET);
					request.AddHeader("cache-control", "no-cache");
					request.AddHeader("authorization", $"Basic {base64EncodedCredentials}");

					var response = await client.Execute(request);

                    return response.RawBytes;
				}
			}
            catch(InternetConnectionException)
            {
                throw;
            }
            catch(System.Net.Http.HttpRequestException ex)
            {
                if (ex.Message == "404 (Not Found)")
                    throw new FileNotFoundException($"The file at {fileUrl} cannot be found.", ex);
                else
                    throw new FileErrorException($"There was an error while attemping to get the bytes for the file at {fileUrl}", ex);
            }
			catch (Exception ex)
			{
                throw new DataRepositoryException($"There was an error while attempting to get the file at {fileUrl}", ex);
			}
        }
    }
}
