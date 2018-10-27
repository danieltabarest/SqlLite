using System.Threading.Tasks;

namespace NsuGo.Definition.Interfaces.Repositories.Remote.Base
{
    public interface IRequestProvider
    {
		Task<TResult> GetAsync<TResult>(string uri);

        Task<string> PostAsync(string uri, string data);

        Task<bool> DoPostAsync<TRequest>(string uri, TRequest data);

		Task<TResult> PostAsync<TResult>(string uri, TResult data);

		Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data);

		Task<TResult> PutAsync<TResult>(string uri, TResult data);

		Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data);
    }
}
