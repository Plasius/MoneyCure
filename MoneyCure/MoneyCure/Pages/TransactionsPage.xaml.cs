﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Model.Transaction> Transactions;
        public TransactionsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //get transactions
            //Transactions = App.SQLiteDb.GetExpenses().Result;

        }


        //EVENT HANDLERS

        public async void OnSettingsClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new SettingsPage());
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
}