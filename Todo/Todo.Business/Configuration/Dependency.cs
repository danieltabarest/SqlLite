using NsuGo.Business.DataManagers;
using NsuGo.Definition.Interfaces.DataManagers;
using NsuGo.Framework.Interfaces;

namespace NsuGo.Business.Configuration
{
    public static class Dependency
    {
        public static void Init(IInjection injection)
        {
            DatabaseAccess.Configuration.Dependency.Init(injection);
            RegisterDataManagers(injection);
        }

        private static void RegisterDataManagers(IInjection injection)
        {
            injection.Register<IAccountHoldManager, AccountHoldManager>();
        }
    }
}
