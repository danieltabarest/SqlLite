using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Todo.Common.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Interfaces.Services;

namespace NsuGo.ServiceAccess.Repositories.Base
{
    public class RequestProvider : IRequestProvider
    {
		private const string _pathPrefix = "appcentral/";

		private readonly JsonSerializerSettings _serializerSettings;
        private readonly Uri _baseUri = new Uri(Preferences.ApiBaseAddress);
		private readonly IAuthenticationService _authenticatorService;

		public RequestProvider(IAuthenticationService authenticatorService)
		{
			_authenticatorService = authenticatorService;

			_serializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				DateTimeZoneHandling = DateTimeZoneHandling.Utc,
				NullValueHandling = NullValueHandling.Ignore
			};

			_serializerSettings.Converters.Add(new StringEnumConverter());
		}

		public async Task<TResult> GetAsync<TResult>(string uri)
		{
			var serialized = string.Empty;

			try
			{
                HttpClient httpClient = await CreateHttpClientAsync();
				var response = await httpClient.GetAsync(_pathPrefix + uri);

				await HandleResponse(response);

				serialized = await response.Content.ReadAsStringAsync();
			}
			catch (HttpRequestException ex)
			{
				if (ex.InnerException is System.Net.WebException)
					throw new InternetConnectionException(ex.Message);
				else
					throw;
			}
			catch (Exception)
			{
				throw;
			}

			return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));
		}

		public Task<TResult> PostAsync<TResult>(string uri, TResult data)
		{
			return PostAsync<TResult, TResult>(uri, data);
		}

		public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
		{
            var responseData = string.Empty;

            try
            {
                HttpClient httpClient = await CreateHttpClientAsync();
				string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
                HttpResponseMessage response = await httpClient.PostAsync(_pathPrefix + uri, new StringContent(serialized, System.Text.Encoding.UTF8, "text/json"));

				await HandleResponse(response);

				responseData = await response.Content.ReadAsStringAsync();

			}
            catch (HttpRequestException ex)
            {
                if (ex.InnerException is System.Net.WebException)
                    throw new InternetConnectionException(ex.Message);
                else
                    throw;
            }
            catch (Exception)
            {
                throw;
            }

			return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
		}


        public async Task<bool> DoPostAsync<TRequest>(string uri, TRequest data)
		{
            var isSuccess = false;

			try
			{
				HttpClient httpClient = await CreateHttpClientAsync();
				string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
				HttpResponseMessage response = await httpClient.PostAsync(_pathPrefix + uri, new StringContent(serialized, System.Text.Encoding.UTF8, "text/json"));

				await HandleResponse(response);

                var responseData = await response.Content.ReadAsStringAsync();

                if (responseData.ToLower() == "true")
                    isSuccess = true;
			}
			catch (HttpRequestException ex)
			{
				if (ex.InnerException is System.Net.WebException)
					throw new InternetConnectionException(ex.Message);
				else
					throw;
			}
			catch (Exception)
			{
				throw;
			}

            return isSuccess;
		}

        public Task<string> PostAsync(string uri, string data)
        {
            return PostAsync<string>(uri, data);
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data)
		{
			throw new NotImplementedException();
		}

		public Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
		{
			throw new NotImplementedException();
		}


        private async Task<HttpClient> CreateHttpClientAsync()
		{
            var accessToken = await _authenticatorService.GetAccessTokenAsync();
            var httpClient = new HttpClient
            {
                BaseAddress = _baseUri
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            return httpClient;
        }

		private async Task HandleResponse(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
				{
					// throw new AuthenticationException(content);
				}

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new AuthenticationException(content);

				throw new HttpRequestException(content);
			}
		}
    }
}
