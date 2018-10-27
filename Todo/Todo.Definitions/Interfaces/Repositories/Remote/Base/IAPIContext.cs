using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Dtos.Api.Base;

namespace NsuGo.Definition.Interfaces.Repositories.Remote.Base
{
    public interface IAPIContext
    {
        Task<TResource> GetResourceAsync<TResource, TJsonObject>(string uri, string exceptionMessage) 
            where TResource : class
            where TJsonObject : JsonObject<TResource>;

        Task<string> GetResourceAsync(string uri, string exceptionMessage);

        Task<IEnumerable<TResource>> GetResourcesAsync<TResource, TJsonObject>(string uri, string exceptionMessage)
            where TResource : class
            where TJsonObject : JsonObject<TResource>;

        Task<string> PostResourceAsync(string uri, string data, string exceptionMessage);

        Task<bool> PostActionAsync<TJsonObject>(string uri, TJsonObject data, string exceptionMessage)
            where TJsonObject : class;

        Task<IEnumerable<TResource>> PostAsync<TResource, TJsonObject, TRequest>(string uri, TRequest data, string exceptionMessage)
            where TResource : class
            where TJsonObject : JsonObject<TResource>;
	}
}
