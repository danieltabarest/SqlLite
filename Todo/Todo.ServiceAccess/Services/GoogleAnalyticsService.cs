
using NsuGo.Definition.Interfaces.Services;

namespace NsuGo.ServiceAccess.Services
{
    public class GoogleAnalyticsService : IAnalyticsService
    {
        public void TrackEvent(string category, string action, string label)
        {
            throw new System.NotImplementedException();
        }

        public void TrackEvent(string category, string action)
        {
            throw new System.NotImplementedException();
        }

        public void TrackPage(string pageName)
        {
            throw new System.NotImplementedException();
        }
    }
}
