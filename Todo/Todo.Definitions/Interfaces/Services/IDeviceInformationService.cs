namespace NsuGo.Definition.Interfaces.Services
{
    public interface IDeviceInformationService
    {
        string Id { get; }

        string Model { get; }

        string Version { get; }

        string VersionNumber { get; }

        string Platform { get; }

        string Idiom { get; }

        string ToString();
    }
}
