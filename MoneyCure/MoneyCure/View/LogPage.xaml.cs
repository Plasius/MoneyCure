using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyCure.Model;
using MoneyCure.Data;

namespace MoneyCure.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogPage : ContentPage
    {
        bool IsExpense = false, Selected=false;
        public LogPage()
        {
            InitializeComponent();
            var list = Enum.GetValues(typeof(Utils.Categories)).Cast<Utils.Categories>().ToList();
            list.Remove(Utils.Categories.Income);
            list.Remove(Utils.Categories.Savings);
            picker.ItemsSource = list;
        }

        public void ClickedExp(object sender, EventArgs eventArgs) {
            Inc.BackgroundColor = Color.LightGray;
            Exp.BackgroundColor = Color.LightSkyBlue;
            IsExpense = true;
            Selected = true;
            picker.IsVisible = true;
        }

        public void ClickedInc(object sender, EventArgs eventArgs)
        {
            Exp.BackgroundColor = Color.LightGray;
            Inc.BackgroundColor = Color.LightSkyBlue;
            IsExpense = false;
            Selected = true;
            picker.IsVisible = false;
        }

        public void ClickedSub(object sender, EventArgs eventArgs)
        {
            if (Selected)
            {
                double am = 0;
                if (!Utils.NullorEmpty(Amount.Text) && double.TryParse(Amount.Text,out am)) { am = Math.Round(double.Parse(Amount.Text),2); }
                else {
                    DisplayAlert("Error", "Please enter the amount", "OK");
                    return;
                }
                if (Utils.NullorEmpty(DesCript.Text))
                {
                    DisplayAlert("Error","Description can't be empty","OK");
                    return;
                }
                if (am >= 0.01)
                {
                    double loBal = Data.Utils.GetInstance().GetDouble("CheckingBalance", 0);

                    DateTime Day = DateTime.Now;

                    if (IsExpense)
                    {
                        if (picker.SelectedIndex == -1)
                        {
                            DisplayAlert("Error", "Don't forget the picker", "OK");
                            return;
                        }
                        if (loBal < am)
                        {
                            DisplayAlert("Error", "You don't heve enough money", "I'm broke");
                            return;
                        }
                        else
                        {
                            am *= -1;

                            Data.Utils.GetInstance().SetDouble("CheckingBalance", am + loBal);

                            Transaction Tr = new Transaction(am, Day, DesCript.Text, picker.SelectedIndex+1);
                            App.SQLiteDb.CreateTransaction(Tr);
                        }
                    }
                    else
                    {
                        if (loBal + am > 1000000)
                        {
                            DisplayAlert("Error", "Mo' Money, Mo' Problems", "OK");
                        }

                        Data.Utils.GetInstance().SetDouble("CheckingBalance",am+loBal);


                        Transaction Tr = new Transaction(am, Day, DesCript.Text, -1);
                        App.SQLiteDb.CreateTransaction(Tr);
                    }

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "Amount too small!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error","Please select Income/Expense", "OK");
            }
        }
    }
}