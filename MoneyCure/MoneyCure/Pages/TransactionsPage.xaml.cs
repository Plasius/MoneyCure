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
    public partial class TransactionsPage : ContentPage
    {
        public TransactionsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        

        //EVENT HANDLERS
        public async void OnSavingsClicked(object sender, EventArgs eventArgs) {
            await Navigation.PushAsync(new SavingsPage());
        }

        public async void OnReportsClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new ReportsPage());
        }
    }
}