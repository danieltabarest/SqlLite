using Todo.Droid.PlatformProviders;
using NsuGo.Definition.Interfaces.PlatformProviders;
using NsuGo.Framework.Interfaces;

namespace Todo.Droid
{
    public class Bootstrapper : IPlatformBootstrapper
    {
        public void Register(IInjection injection)
        {
            injection.Register<IFileSystemProvider, FileSystemProvider>();
        }
    }
}
