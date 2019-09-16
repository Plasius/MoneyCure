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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

        }

        async void Subbt (object sender, EventArgs args)
        {
            if (Pin1.Text != null && Pin1.Text == Pin2.Text && Goal.Text != null)
            {

                Data.Utils.GetInstance().SetInt("SavingsGoal", int.Parse(Goal.Text));
                Data.Utils.GetInstance().SetInt("PINCode", int.Parse(Pin1.Text));
                Data.Utils.GetInstance().SetBool("StayLoggedIn", false);
                await Navigation.PopAsync();

            }
            else {
                await DisplayAlert("Error", "Information is not valid.", "OK");
            }

        }
    }
}