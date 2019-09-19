using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyCure.Controller;
using MoneyCure.Data;

namespace MoneyCure.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        bool fromLogin;
        public SettingsPage(bool hideResetButton)
        {
            InitializeComponent();
            fromLogin = hideResetButton;
            resetButton.IsVisible = !hideResetButton;

        }

        async void SetPin (object sender, EventArgs args)
        {
            
            if (!Utils.NullorEmpty(Pin1.Text) && Pin1.Text.Length==4)
            {
                Data.Utils.GetInstance().SetString("PINCode", Pin1.Text);
                if (fromLogin)
                {
                    Reset(null, null);
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Error", "Information is not valid.", "OK");
            }

        }
        async void SetGoal(object sender, EventArgs args)
        {
            int logoal;
            if(!Utils.NullorEmpty(Goal.Text) && int.TryParse(Goal.Text, out logoal) && int.Parse(Goal.Text) > 0)
                {
                    Data.Utils.GetInstance().SetDouble("SavingsGoal", int.Parse(Goal.Text));
                    await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Information is not valid.", "OK");
            }
            
        }
        async void Reset(object sender, EventArgs args)
        {
            await App.SQLiteDb.DeleteAllTransactions();
            Data.Utils.GetInstance().SetDouble("CheckingBalance", 0);
            Data.Utils.GetInstance().SetDouble("SavingsBalance", 0);

            await Navigation.PopAsync();
        }
    }
}