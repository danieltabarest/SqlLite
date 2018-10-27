using NsuGo.Definition.Interfaces.PlatformProviders;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Interfaces.Repositories.Remote.Base;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Framework.Interfaces;
using NsuGo.ServiceAccess.Repositories;
using NsuGo.ServiceAccess.Repositories.Base;
using NsuGo.ServiceAccess.Repositories.Fakes;
using NsuGo.ServiceAccess.Services;

namespace NsuGo.ServiceAccess.Configuration
{
    public static class Dependency
    {
        public static void Init(IInjection injection)
        {
            injection.Register<IRequestProvider, RequestProvider>();
            injection.Register<IAPIContext, APIContext>();
            injection.Register<ICoursesService, CoursesService>();
            injection.Register<IConnectivityService, ConnectivityService>();
            RegisterFileSystemService(injection);
        }

        private static void RegisterFileSystemService(IInjection injection)
        {
            var fileSystemProvider = injection.Resolve<IFileSystemProvider>();
            injection.Register<IFileSystemService>(new FileSystemService(fileSystemProvider));
        }

    }
}
