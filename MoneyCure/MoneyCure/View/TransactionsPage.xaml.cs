using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyCure.Model;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyCure.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionsPage : ContentPage
    {
        ObservableCollection<Model.Transaction> Transactions;

        public TransactionsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //notification
            if (Data.Utils.GetInstance().GetDouble("CheckingBalance", 500) < 20)
                CrossLocalNotifications.Current.Show("Running low", "Add some funds to your account.", 0);

        }

        protected override void OnAppearing()
        {
            //get balance
            balanceLabel.Text = Data.Utils.GetInstance().GetDouble("CheckingBalance", 0).ToString() + " EUR";

            //get transactions
            Transactions = new ObservableCollection<Transaction>(App.SQLiteDb.GetTransactions().Result);

            //bind transactions
            transactionsListView.ItemsSource = Transactions;
        }

        //EVENT HANDLERS

        public async void OnSettingsClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new SettingsPage(false));
        }

        public async void OnAddTransactionClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new LogPage());
        }


        public void OnSavingsClicked(object sender, EventArgs eventArgs)
        {
            App.Current.MainPage = new NavigationPage(new SavingsPage());
        }

        public void OnReportsClicked(object sender, EventArgs eventArgs)
        {
            App.Current.MainPage = new NavigationPage(new ReportsPage());
        }



    }

    public class CategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Data.Utils.Categories)((int)value)).ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}