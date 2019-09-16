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
            Data.Utils.GetInstance().SetString("UserFirstName", "User");
            Data.Utils.GetInstance().SetString("UserLastName", "User");
            if (Pin1.Text != Pin2.Text)
            {
                await DisplayAlert("Error","Pin doesn't match","Try again");
                return;
            }
            else
            {
                if (Pin1 == null)
                {
                    await DisplayAlert("Error", "You must set a PIN", "OK");
                                    return;
                }

                Data.Utils.GetInstance().SetInt("PINCode", int.Parse(Pin1.Text));
                await Navigation.PopAsync();
            }
            Data.Utils.GetInstance().SetInt("SavingsGoal", 0);
        }
    }
}