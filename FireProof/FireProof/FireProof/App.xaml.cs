using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FireProof
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        static ItemDatabase database;
        public static ItemDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new ItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ItemSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=a1751ded-27d8-4ff1-8ba1-c3078989189d;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
