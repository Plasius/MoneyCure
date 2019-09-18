using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyCure.Data;

namespace MoneyCure.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavingsPage : ContentPage
    {
        protected override void OnAppearing()
        {
            double a = Data.Utils.GetInstance().GetDouble("SavingsBalance", 0);
            double b = Data.Utils.GetInstance().GetDouble("SavingsGoal", 0);
            SaveNum.Text = Math.Round(a, 2).ToString() + " / " + Math.Round(b, 2).ToString();

            int progress = (int)((a / b) * 10);

            if (progress >= 1)
            {
                B1.BackgroundColor = Color.SkyBlue;
            }
            else {
                B1.BackgroundColor = Color.LightGray;
                B2.BackgroundColor = Color.LightGray;
                B3.BackgroundColor = Color.LightGray;
                B4.BackgroundColor = Color.LightGray;
                B5.BackgroundColor = Color.LightGray;
                B6.BackgroundColor = Color.LightGray;
                B7.BackgroundColor = Color.LightGray;
                B8.BackgroundColor = Color.LightGray;
                B9.BackgroundColor = Color.LightGray;
                B10.BackgroundColor = Color.LightGray;
            }
            if (progress >= 2)
            {
                B2.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 3)
            {
                B3.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 4)
            {
                B4.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 5)
            {
                B5.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 6)
            {
                B6.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 7)
            {
                B7.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 8)
            {
                B8.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 9)
            {
                B9.BackgroundColor = Color.SkyBlue;
            }
            if (progress >= 10)
            {
                B10.BackgroundColor = Color.SkyBlue;
            }

        }

        public SavingsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnSettingsClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        public void Addbt(object sender, EventArgs args)
        {
            /*
             check CheckingBalance ha van eleg penz felrerakni
             levonjuk a penzt a CheckingBalancebol
             Hozzaadjuk SavingsBalance
             new Transaction category==savings
             
             */
            
            if (Utils.NullorEmpty( More.Text))
            {
                DisplayAlert("Error", "Can't add saving", "OK");
                return;
            }
                
            int megtakaritando;

            if (int.TryParse(More.Text, out megtakaritando))
            {
                if (megtakaritando < 0)
                {
                    DisplayAlert("Error", "Amount can't be negative", "OK");
                    return;
                }

                if (Data.Utils.GetInstance().GetDouble("CheckingBalance", 0) < megtakaritando)
                {
                    DisplayAlert("Error", "Not enough money", "OK");
                    return;

                }


                Data.Utils.GetInstance().SetDouble("CheckingBalance", Data.Utils.GetInstance().GetDouble("CheckingBalance", 0) - megtakaritando);

                double currentSavingsBalance = Data.Utils.GetInstance().GetDouble("SavingsBalance", 0);
                Data.Utils.GetInstance().SetDouble("SavingsBalance", currentSavingsBalance + megtakaritando);

                App.SQLiteDb.CreateTransaction(new Model.Transaction(megtakaritando, DateTime.Now, "Savings", (int)Data.Utils.Categories.Savings));



                OnAppearing();
                double a = Data.Utils.GetInstance().GetDouble("SavingsBalance", currentSavingsBalance + megtakaritando);
                double b = Data.Utils.GetInstance().GetDouble("SavingsGoal", currentSavingsBalance + megtakaritando);
                SaveNum.Text = Math.Round(a, 2).ToString() + " / " + Math.Round(b, 2).ToString();
            }
            else
            {
                DisplayAlert("Error", "Can't add saving", "OK");
                return;
            }
        }
        
        public void OnAmountClicked(object sender, EventArgs args)
        {
            //change selected colors
            More.Text = ((Button)sender).Text;
            Ambt1.BackgroundColor = Color.LightGray;
            Ambt2.BackgroundColor = Color.LightGray;
            Ambt3.BackgroundColor = Color.LightGray;
            Ambt4.BackgroundColor = Color.LightGray;
            ((Button)sender).BackgroundColor = Color.LightSkyBlue;
        }

        //EVENT HANDLERS
        public void OnTransactionsClicked(object sender, EventArgs eventArgs)
        {

            App.Current.MainPage = new NavigationPage(new TransactionsPage());
        }

        public void OnReportsClicked(object sender, EventArgs eventArgs)
        {

            App.Current.MainPage = new NavigationPage(new ReportsPage());
        }
        
    }
}