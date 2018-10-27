using System.Threading.Tasks;


using NsuGo.Definition.Interfaces.Services;

namespace NsuGo.Business.DataManagers.Base
{
    public abstract class BaseDataManager
    {
        protected abstract void OnPurgeMessageRecieved();

        protected abstract void OnUpdateDataMessageRecieved();

        //protected virtual void SubscribeForNotifications(object subscriber)
        //{
        //    subscriber.Subscribe(async (Message obj) => await HandleNotificationMessagesAsync(obj));
        //}

        //protected virtual async Task HandleNotificationMessagesAsync(Message message)
        //{
        //    if (message == Message.PurgeLocalStorage)
        //        OnPurgeMessageRecieved();

        //    else if (message == Message.UpdateAllData)
        //        OnUpdateDataMessageRecieved();

        //    await Task.FromResult<object>(null);
        //}

        protected virtual void OnCriticalUpdateCompleted()
        {
            //this.Send(Message.CriticalDataUpdated);
        }

        protected virtual void OnUpdateCompleted()
        {
            //this.Send(Message.AllDataUpdated);
        }

        protected virtual Task OnCriticalUpdateMessageRecievedAsync()
        {
            return Task.FromResult(default(object));
        }

        protected async Task<bool> CannotReachHostAsync(IConnectivityService connectivityService)
        {
            return !(await connectivityService.IsRemoteReachableAsync(Todo.Common.Helpers.Preferences.ApiBaseAddress));

        }

    }
}
