using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            await Navigation.PushAsync(new SettingsPage());
        }

        public async void OnLoginClicked(object sender, EventArgs args)
        {
            //check if the passwords match
            int toMatch = Data.Utils.GetInstance().GetInt("PINCode", -1);
            if (toMatch == -1 || pinEntry.Text == null)
            {
                await DisplayAlert("Invalid PIN", "Insert your correct PIN code.", "OK");
                return;
            }

            if (int.Parse(pinEntry.Text) == toMatch)
            {
                //successfully logged in
                App.Current.MainPage = new NavigationPage(new TransactionsPage());
            }
            else
                await DisplayAlert("Invalid PIN", "Insert your correct PIN code.", "OK");
        }

    }
}
