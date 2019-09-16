using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyCure.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavingsPage : ContentPage
    {
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
            if(((Button)sender).Text != null)
                Data.Utils.GetInstance().SetInt("Amount", int.Parse(((Button)sender).Text));
        }
        
        public void OnAmountClicked(object sender, EventArgs args)
        {
            //change selected colors
            
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