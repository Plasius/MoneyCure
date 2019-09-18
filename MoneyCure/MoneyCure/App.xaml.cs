using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyCure.Pages;
using MoneyCure.Controller;
using System.IO;
using Plugin.LocalNotifications;

namespace MoneyCure
{

    public partial class App : Application
    {


        static SQLiteHelper db;
        public static SQLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mcdb.db3"));
                }
                return db;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            //notification
            if(Data.Utils.GetInstance().GetDouble("CheckingBalance", 500) < 20)
                CrossLocalNotifications.Current.Show("Running low", "Add some funds to your account.", 0, DateTime.Now.AddMinutes(1));


        }

        protected override void OnStart()
        {
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
