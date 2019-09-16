using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoneyCure.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            pinEntry.Focus();

        }
        public  void OnButtonClicked(object sender, EventArgs args)
        {
            //check if the passwords match
            int toMatch = Data.Utils.GetInstance().GetInt("PINCode", -1);
            if (toMatch == -1 || pinEntry.Text == null)
                return;

            if(int.Parse(pinEntry.Text) == toMatch)
                App.Current.MainPage = new NavigationPage(new TransactionsPage());
            else
                Console.WriteLine("Invalid pass");
        }

    }
}
