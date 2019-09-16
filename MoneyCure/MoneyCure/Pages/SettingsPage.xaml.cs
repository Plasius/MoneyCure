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
            Data.Utils.GetInstance().SetString()
            if (Pin1.Text != Pin2.Text)
            {
                DisplayAlert("Error","Pin doesn't match","Try again");
            }
            else
            {
                if (Pin2 == null)
                    DisplayAlert("Error", "You must set a PIN", "OK");
                Data.Utils.GetInstance().SetInt("PINCode", -1);
                Navigation.PopAsync();
            }
        }
    }
}