using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NsuGo.Framework.Interfaces;
using Todo;
using System.Threading.Tasks;
using Plugin.Permissions.Abstractions;
using Todo.Common.Utils;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
    public class App : Application
    {
        static TodoItemDatabase database;

        public App(IPlatformBootstrapper platformBootstrapper)
        {

            Bootstrapper.GetInstance(platformBootstrapper).Init();

            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new TodoListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;


            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += async (sender, args) => {
                await Task.Run(async () => await EnforceDataIntegrityAsync());
            };

            MainPage = nav;

        }


        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await Task.Run(async () => await EnforceDataIntegrityAsync());
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnResume()
        {
            // Handle when your app resumes
            await Task.Run(async () => await EnforceDataIntegrityAsync());
        }

        private async void InitializeAppPermissionsAsync()
        {
            var hasPermission = await Utils.CheckPermissions(Permission.Location);
            if (!hasPermission)
                return;
        }


        private async Task EnforceDataIntegrityAsync()
        {
            var dataIntegrityManager = DataIntegrityManager.GetInstance();

            dataIntegrityManager.EnforceUserSecurity();
            await dataIntegrityManager.EnforceFreshDataAsync();
        }
    }
}

