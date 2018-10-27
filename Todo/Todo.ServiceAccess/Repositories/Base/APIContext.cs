using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api.Base;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;

namespace NsuGo.ServiceAccess.Repositories.Base
{
    // TODO: Log errors from request attempts
    public class APIContext : IAPIContext
    {
        private readonly IRequestProvider _requestProvider;

        public APIContext(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<IEnumerable<TResource>> GetResourcesAsync<TResource, TJsonObject>(string uri, string exceptionMessage) 
            where TResource : class
            where TJsonObject : JsonObject<TResource>
        {
            var resources = new List<TResource>();

			try
			{
                var jsonObjects = await _requestProvider.GetAsync<IEnumerable<TJsonObject>>(uri);

				foreach (var jsonObject in jsonObjects)
					resources.Add(jsonObject.ToDomainModel());
			}
			catch (InternetConnectionException)
			{
				throw;
			}
            catch (AuthenticationException)
            {
                throw;
            }
			catch (Exception ex)
			{
                throw new DataRepositoryException(exceptionMessage, ex);
			}

            return resources;

		}

        public async Task<TResource> GetResourceAsync<TResource, TJsonObject>(string uri, string exceptionMessage)
			where TResource : class
            where TJsonObject : JsonObject<TResource>
		{
            var resource = typeof(TResource) == typeof(string) ? (TResource)(object)string.Empty : (TResource)Activator.CreateInstance(typeof(TResource), new object[] { });

			try
			{
				var jsonObject = await _requestProvider.GetAsync<TJsonObject>(uri);

                resource = jsonObject.ToDomainModel();
			}
			catch (InternetConnectionException)
			{
				throw;
			}
            catch (AuthenticationException)
            {
                throw;
            }
			catch (Exception ex)
			{
				throw new DataRepositoryException(exceptionMessage, ex);
			}

			return resource;

		}

        public async Task<string> GetResourceAsync(string uri, string exceptionMessage)
        {
            var resource = string.Empty;

			try
			{
				resource = await _requestProvider.GetAsync<string>(uri);
			}
			catch (InternetConnectionException)
			{
				throw;
			}
            catch (AuthenticationException)
            {
                throw;
            }
			catch (Exception ex)
			{
				throw new DataRepositoryException(exceptionMessage, ex);
			}

			return resource;
        }

        public async Task<string> PostResourceAsync(string uri, string data, string exceptionMessage)
        {
            var resource = string.Empty;

            try
            {
                resource = await _requestProvider.PostAsync(uri, data);
            }
            catch (InternetConnectionException)
            {
                throw;
            }
            catch (AuthenticationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException(exceptionMessage, ex);
            }

            return resource;
        }

        public async Task<bool> PostActionAsync<TJsonObject>(string uri, TJsonObject data, string exceptionMessage) where TJsonObject : class
        {
            var isSuccess = false;

            try
            {
                isSuccess = await _requestProvider.DoPostAsync<TJsonObject>(uri, data);
            }
            catch(InternetConnectionException)
            {
                throw;
            }
            catch(AuthenticationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException(exceptionMessage, ex);
            }

            return isSuccess;
        }

        public async Task<IEnumerable<TResource>> PostAsync<TResource, TJsonObject, TRequest>(string uri, TRequest data, string exceptionMessage)
            where TResource : class
            where TJsonObject : JsonObject<TResource>
        {
            try
            {
                var resources = new List<TResource>();
                var jsonObjects = await _requestProvider.PostAsync<TRequest, IEnumerable<TJsonObject>>(uri, data);

                foreach (var jsonObject in jsonObjects)
                    resources.Add(jsonObject.ToDomainModel());

                return resources;

            }
            catch (InternetConnectionException)
            {
                throw;
            }
            catch (AuthenticationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException(exceptionMessage, ex);
            }
        }
    }
}
