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
    public partial class ReportsPage : ContentPage
    {
        public ReportsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        //EVENT HANDLERS
        public async void OnSettingsClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
        public void OnSavingsClicked(object sender, EventArgs eventArgs)
        {
            App.Current.MainPage = new NavigationPage(new SavingsPage());
        }

        public void OnTransactionsClicked(object sender, EventArgs eventArgs)
        {
            App.Current.MainPage = new NavigationPage(new TransactionsPage());
        }

        protected override void OnAppearing()
        {
            var lst = App.SQLiteDb.GetExpenses().Result;
            double[] categoriesAmount = new double[10];

            double transSum = 0;

            foreach (var trans in lst) {
                categoriesAmount[trans.CatId] += Math.Abs(trans.Amount);
                transSum += Math.Abs(trans.Amount);
            }

            for (int i=0; i<10; i++) {
                if (categoriesAmount[i] > 0) {

                }
            }

            Label temp;
            for( int i=0; i<10; i++)
            {
                for(int j=0; j<3; j++)
                {
                    switch (j) {
                        case 0:
                            temp = new Label { Text = ((Data.Utils.Categories)i).ToString() };
                            expenseGrid.Children.Add(temp, j, i+1);
                            break;
                        case 1:
                            temp = new Label { Text = categoriesAmount[i].ToString() };
                            expenseGrid.Children.Add(temp, j, i+1);
                            break;
                        case 2:
                            temp = new Label { Text = (categoriesAmount[i]*100/transSum).ToString() };
                            expenseGrid.Children.Add(temp, j, i+1);
                            break;

                    }
                }
            }


        }
    }
}