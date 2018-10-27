namespace NsuGo.Definition.Interfaces.Services
{
    public interface IAnalyticsService
    {
        void TrackPage(string pageName);

        void TrackEvent(string category, string action, string label);

        void TrackEvent(string category, string action);
    }
}
