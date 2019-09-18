using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MoneyCure.Data;

namespace MoneyCure.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        public async void OnRegisterClicked(object sender, EventArgs eventArgs) {
            await Navigation.PushAsync(new SettingsPage(true));
        }

        public async void OnLoginClicked(object sender, EventArgs args)
        {
            //check if the passwords match
            string toMatch = Data.Utils.GetInstance().GetString("PINCode", "-1");
            if (toMatch == "-1" || Utils.NullorEmpty(pinEntry.Text))
            {
                await DisplayAlert("Invalid PIN", "Insert your correct PIN code.", "OK");
                return;
            }

            if (pinEntry.Text.Equals(toMatch))
            {
                //successfully logged in
                App.Current.MainPage = new NavigationPage(new TransactionsPage());
            }
            else
                await DisplayAlert("Invalid PIN", "Insert your correct PIN code.", "OK");
        }

    }
}
