using System;
using System.Threading.Tasks;
using FreshMvvm;
using Todo.Common.Helpers;
using NsuGo.Definition.Interfaces.DataManagers;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Interfaces.Services;

namespace Todo
{
    public class DataIntegrityManager
    {
        private readonly ICoursesService _courseService;
        private readonly ICourseRepository _courseRepository;
        private readonly IConnectivityService _connectivityService;
        private static DataIntegrityManager _instance;
        private readonly NsuGo.Definition.Interfaces.DataManagers.ICourseManager _courseManager;

        private DataIntegrityManager(ICoursesService courseService,
            ICourseRepository courseRepository, NsuGo.Definition.Interfaces.DataManagers.ICourseManager courseManager)
        {
            _courseService = courseService;
            _courseManager = courseManager;
            _courseRepository = courseRepository;
            _connectivityService = FreshIOC.Container.Resolve<IConnectivityService>();
            //this.Subscribe<Message>(HandleMessageNotifications);
        }

        public DataIntegrityManager()
        {
            _connectivityService = FreshIOC.Container.Resolve<IConnectivityService>();
            _courseService = FreshIOC.Container.Resolve<ICoursesService>();
            _courseRepository = FreshIOC.Container.Resolve<ICourseRepository>();
            _courseManager = FreshIOC.Container.Resolve<ICourseManager>(); ;
        }

        public static DataIntegrityManager GetInstance()
        {
            if (_instance == null)
                _instance = new DataIntegrityManager();

            return _instance;
        }

        public async Task EnforceFreshDataAsync()
        {
            await EnsureCriticalDataIsUpdatedAsync();
            await EnsureDataIsUpdatedAsync();
        }

        //private void HandleMessageNotifications(Message message)
        //{
        //    if (message == Message.CriticalDataUpdated)
        //        OnCriticalDataUpdatedMessageRecieved();

        //    else if (message == Message.AllDataUpdated)
        //        OnAllDataUpdatedMessageRecieved();
        //}

        private void OnAllDataUpdatedMessageRecieved()
        {
            UserSettings.LastDataUpdate = DateTime.UtcNow;
            UserSettings.LastCriticalDataUpdate = UserSettings.LastDataUpdate;
        }

        private void OnCriticalDataUpdatedMessageRecieved()
        {
            UserSettings.LastCriticalDataUpdate = DateTime.UtcNow;
        }

        public void EnforceUserSecurity()
        {
            EnsureValidUserSession();
        }

        private async Task EnsureCriticalDataIsUpdatedAsync()
        {
            if (_connectivityService.IsConnected)
            {
                bool isHostReachable = await CheckHostsReachabilityAsync();

                if (IsCriticalDataUpdateRequired() && isHostReachable)
                    await OnCriticalUpdateMessageRecievedAsync();
            }
        }

        protected async Task OnCriticalUpdateMessageRecievedAsync()
        {
            System.Diagnostics.Debug.WriteLine("Critical update message recieved in grades manager.");

            await SaveAllGradesToLocalStorage();
            RemoveAllGradesFromLocalStorage();
        }

        private async Task SaveAllGradesToLocalStorage()
        {
            var courses = await _courseManager.CoursesAsync();

            var grades = await _courseService.CoursesAsync();
            SaveToLocalStorage(grades);
        }

        private void RemoveAllGradesFromLocalStorage()
        {
            _courseRepository.RemoveAll();
        }
        private async Task<bool> CheckHostsReachabilityAsync()
        {
            return await _connectivityService.IsRemoteReachableAsync(Preferences.ApiBaseAddress);
        }

        private void SaveToLocalStorage(object accountSummary)
        {
            //_courseRepository.Add(accountSummary);
        }



        private async Task EnsureDataIsUpdatedAsync()
        {
            bool isHostReachable = await CheckHostsReachabilityAsync();

            //if (IsDataUpdateRequired() && isHostReachable)
            //this.Send(Message.UpdateAllData);
        }

        private void EnsureValidUserSession()
        {
            //if (IsUserSessionExpired())
            //this.Send(Message.LogOut);
        }

        private bool IsCriticalDataUpdateRequired()
        {
            if (UserSettings.IsFirstTime)
                return false;

            var criticalUpdateTimeDate = UserSettings.LastCriticalDataUpdate
                                                     .AddMinutes(Preferences.CriticalDataUpdateIntervalInMinutes);

            return (DateTime.UtcNow >= criticalUpdateTimeDate);
        }

        private bool IsDataUpdateRequired()
        {
            if (UserSettings.IsFirstTime)
                return false;

            var dataUpdateTimeDate = UserSettings.LastDataUpdate
                                                 .AddHours(Preferences.AllDataUpdateIntervalInHours);

            return (DateTime.UtcNow >= dataUpdateTimeDate);
        }

        private bool IsUserSessionExpired()
        {
            if (UserSettings.IsFirstTime)
                return false;

            var userSessionExpiryDateTime = UserSettings.LastLogin
                                                        .AddHours(Preferences.UserSessionLifetimeInHours);

            return (DateTime.UtcNow >= userSessionExpiryDateTime);
        }
    }
}
