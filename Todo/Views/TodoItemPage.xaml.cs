using System;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoItemPage : ContentPage
	{
        private readonly NsuGo.Definition.Interfaces.DataManagers.ICourseManager _courseManager;
        private readonly NsuGo.Definition.Interfaces.Services.IConnectivityService _connectivityService;
        public TodoItemPage(NsuGo.Definition.Interfaces.DataManagers.ICourseManager courseManager, NsuGo.Definition.Interfaces.Services.IConnectivityService connectivityService)
        {
            _courseManager = courseManager;
            _connectivityService = connectivityService;

            InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
            try
            {
                var todoItem = (TodoItem)BindingContext;
                if (!_connectivityService.IsConnected)
                {
                    await _courseManager.SaveAsync(todoItem);
                    await App.Database.SaveItemAsync(todoItem);
                    await Navigation.PopAsync();
                }
                else
                {
                  
                }
            }
      
            catch (NsuGo.Definition.Exceptions.ApiHostUnReachableException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            catch (NsuGo.Definition.Exceptions.InternetConnectionException)
            {
                //await DisplayNoConnectionMessage();
            }
            catch (Exception ex)
            {
              
            }


 
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.Database.DeleteItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		void OnSpeakClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
		}
	}
}
