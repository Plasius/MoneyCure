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
        }

        async void Editbt(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
        public async void Addbt(object sender, EventArgs args)
        {

        }
        async void Bt1_(object sender, EventArgs args)
        {
            Bt1.BackgroundColor = Color.LightSkyBlue;
            Bt2.BackgroundColor = Color.LightGray;
            Bt3.BackgroundColor = Color.LightGray;
            Bt4.BackgroundColor = Color.LightGray;
            
        }
        async void Bt2_(object sender, EventArgs args)
        {
            Bt1.BackgroundColor = Color.LightGray;
            Bt2.BackgroundColor = Color.LightSkyBlue;
            Bt3.BackgroundColor = Color.LightGray;
            Bt4.BackgroundColor = Color.LightGray;
        }
        async void Bt3_(object sender, EventArgs args)
        {
            Bt1.BackgroundColor = Color.LightGray;
            Bt2.BackgroundColor = Color.LightGray;
            Bt3.BackgroundColor = Color.LightSkyBlue;
            Bt4.BackgroundColor = Color.LightGray;
        }
        async void Bt4_(object sender, EventArgs args)
        {
            Bt1.BackgroundColor = Color.LightGray;
            Bt2.BackgroundColor = Color.LightGray;
            Bt3.BackgroundColor = Color.LightGray;
            Bt4.BackgroundColor = Color.LightSkyBlue;
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