using NsuGo.Framework.Interfaces;

namespace Todo
{
    public class Bootstrapper
    {
        private readonly IInjection _injection;
        private readonly IPlatformBootstrapper _platformBootstrapper;

        private static Bootstrapper _instance;

        private Bootstrapper(IPlatformBootstrapper platformBootstrapper)
        {
            _platformBootstrapper = platformBootstrapper;
            _injection = new Proxy.Injection();
        }

        public static Bootstrapper GetInstance(IPlatformBootstrapper platformBootstrapper)
        {
            if (_instance == null)
                _instance = new Bootstrapper(platformBootstrapper);

            return _instance;
        }

        public void Init()
        {
            _platformBootstrapper.Register(_injection);

            NsuGo.ServiceAccess.Configuration.Dependency.Init(_injection);
            NsuGo.Business.Configuration.Dependency.Init(_injection);
        }
    }
}
