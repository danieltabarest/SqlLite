
using Todo.Common.Helpers;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Services;
using NsuGo.Framework.Interfaces;

namespace Todo.LocalData.Configuration
{
    public static class Dependency
    {
        public static void Init(IInjection injection)
        {
            var fileSystemService = injection.Resolve<IFileSystemService>();
            injection.Register<IDatabaseProvider>(new DatabaseProvider(fileSystemService.GetFilePath(Preferences.DatabaseFileName)));
        }
    }
}
