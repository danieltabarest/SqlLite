﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Interfaces.Services;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace NsuGo.ServiceAccess.Repositories.Base
{
    public class RestSharpRequestProvider : IRequestProvider
    {
		private const string _pathPrefix = "appcentral/";

		private readonly JsonSerializerSettings _serializerSettings;
		private readonly Uri _baseUri = new Uri("http://fldvd-apinet01.ad.nova.edu/");
		private readonly IAuthenticationService _authenticatorService;

        public RestSharpRequestProvider(IAuthenticationService authenticatorService)
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
                var restClient = CreateRestClient();

                var request = await CreateRequestAsync(_pathPrefix + uri, Method.GET);
                var response = await restClient.Execute(request);
                serialized = HandleResponse(response);
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

        public async Task<string> PostAsync(string uri, string data)
		{
            var responseData = string.Empty;

            try
            {
                var client = CreateRestClient();
                var request = await CreateRequestAsync(_pathPrefix + uri, Method.POST);

                string serialized = await Task.Run(() => JsonConvert.SerializeObject(data.Trim(), _serializerSettings));
                request.AddJsonBody(serialized);

				IRestResponse response = await client.Execute(request);

                responseData = response.Content;
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

            return await Task.Run(() => JsonConvert.DeserializeObject<string>(responseData, _serializerSettings));
		}

        public Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            throw new NotImplementedException();
        }

        private RestClient CreateRestClient()
        {
            return new RestClient
            {
                BaseUrl = _baseUri
            };
        }

        private async Task<RestRequest> CreateRequestAsync(string uri, Method method)
        {
            var accessToken = await _authenticatorService.GetAccessTokenAsync();
            var request = new RestRequest(uri, method);

            request.Parameters.Clear();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-typw", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);

            return request;
        }

        private string HandleResponse(IRestResponse response)
        {
            if(!response.IsSuccess)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new AuthenticationException(response.StatusDescription);

                throw new HttpRequestException(response.Content);
            }

            return response.Content;
        }

        public Task<bool> DoPostAsync<TRequest>(string uri, TRequest data)
        {
            throw new NotImplementedException();
        }
    }
}
