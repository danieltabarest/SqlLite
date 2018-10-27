namespace NsuGo.Framework.Interfaces
{
    public interface IInjection
    {
        void Register<RegisterType, RegisterImplementation>()
            where RegisterType : class
            where RegisterImplementation : class, RegisterType;

        void Register<RegisterType>(RegisterType instance)
            where RegisterType : class;

        ResolveType Resolve<ResolveType>()
            where ResolveType : class;
    }
}
