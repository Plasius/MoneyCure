using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyCure.Pages;
using MoneyCure.Controller;
using System.IO;

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

            if (Data.Utils.GetInstance().GetBool("StayLoggedIn", false))
                MainPage = new NavigationPage(new TransactionsPage());
            else
                MainPage = new NavigationPage(new LoginPage());


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
