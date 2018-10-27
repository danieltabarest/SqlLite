using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Services;
using Plugin.Connectivity;

namespace NsuGo.ServiceAccess.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsConnected
        {
            get
            {
                if (!CrossConnectivity.IsSupported)
                    return true;

                using(var connectivity = CrossConnectivity.Current)
                {
                    return connectivity.IsConnected;
                }
            }
        }

        public async Task<bool> IsRemoteReachableAsync(string host, int port = 80, int msTimeout = 5000)
        {
            if (!CrossConnectivity.IsSupported)
                return true;

            if (!IsConnected)
                return false;

            using(var connectivity = CrossConnectivity.Current)
            {
                return await connectivity.IsRemoteReachable(host, port, msTimeout);
            }
        }


    }
}
