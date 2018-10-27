using FreshMvvm;
using NsuGo.Framework.Interfaces;

namespace Todo.Proxy
{
    public class Injection : FreshTinyIOCBuiltIn, IInjection
    {
        void IInjection.Register<RegisterType>(RegisterType instance)
        {
            Register(instance);
        }

        void IInjection.Register<RegisterType, RegisterImplementation>()
        {
            Register<RegisterType, RegisterImplementation>();
        }
    }
}
