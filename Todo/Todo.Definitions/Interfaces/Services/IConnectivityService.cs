using System.Threading.Tasks;

namespace NsuGo.Definition.Interfaces.Services
{
    public interface IConnectivityService
    {
        bool IsConnected { get; }

        Task<bool> IsRemoteReachableAsync(string host, int port = 80, int msTimeout = 5000);
    }
}
