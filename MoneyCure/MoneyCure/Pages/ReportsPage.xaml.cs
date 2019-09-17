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
            var lst = App.SQLiteDb.GetTransactions().Result;
            double[] categoriesAmount = new double[10];

            double expensesSum = 0;
            double incomeSum = 0;

            foreach (var trans in lst) {

                if (trans.CatId == -1) {
                    incomeSum += Math.Abs(trans.Amount);
                    continue;
                }

                categoriesAmount[trans.CatId] += Math.Abs(trans.Amount);
                expensesSum += Math.Abs(trans.Amount);

            }

            incomeLabel.Text = incomeSum.ToString() + " EUR";
            savingsLabel.Text = categoriesAmount[0].ToString() + " EUR";
            expenseLabel.Text = expensesSum.ToString() + " EUR";

            Label temp;
            int rowIndex = 1;
            for( int i=0; i<10; i++)
            {
                if (categoriesAmount[i] == 0)
                    continue;

                for(int j=0; j<3; j++)
                {
                    switch (j) {
                        case 0:
                            temp = new Label { Text = ((Data.Utils.Categories)i).ToString(), FontSize = 20, HorizontalTextAlignment=TextAlignment.Center };
                            expenseGrid.Children.Add(temp, j, rowIndex);
                            break;
                        case 1:
                            temp = new Label { Text = Math.Round(categoriesAmount[i], 2).ToString(), FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
                            expenseGrid.Children.Add(temp, j, rowIndex);
                            break;
                        case 2:
                            temp = new Label { Text = Math.Round((categoriesAmount[i]*100/ expensesSum), 2).ToString(), FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
                            expenseGrid.Children.Add(temp, j, rowIndex);
                            break;

                    }
                }
                rowIndex++;
            }


        }
    }
}