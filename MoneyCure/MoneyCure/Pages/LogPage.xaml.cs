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
                double am = double.Parse(Amount.Text);
                if (am > 0)
                {
                    if (IsExpense) { am *= -1; }

                    DateTime Day = DateTime.Today;

                    if (IsExpense)
                    {
                        Transaction Tr = new Transaction(am, Day, DesCript.Text, picker.SelectedIndex);
                    }
                    else
                    {
                        Transaction Tr = new Transaction(am, Day, DesCript.Text, -1);
                    }


                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "Amount can't be negative!", "OK");
                }
            }
        }
    }
}