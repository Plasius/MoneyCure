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
        public void OnSavingsClicked(object sender, EventArgs eventArgs) {
            App.Current.MainPage = new NavigationPage(new SavingsPage());
        }

        public void OnReportsClicked(object sender, EventArgs eventArgs)
        {
            App.Current.MainPage = new NavigationPage(new ReportsPage());
        }
    }
}