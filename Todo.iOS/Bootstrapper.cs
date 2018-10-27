using Todo.iOS.PlatformProviders;
using NsuGo.Definition.Interfaces.PlatformProviders;
using NsuGo.Framework.Interfaces;

namespace Todo.iOS
{
    public class Bootstrapper : IPlatformBootstrapper
    {
        public void Register(IInjection injection)
        {
            injection.Register<IFileSystemProvider, FileSystemProvider>();
        }
    }
}
