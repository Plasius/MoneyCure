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
    public partial class LogPage : ContentPage
    {
        bool IsExpense = false, Selected=false;
        public LogPage()
        {
            InitializeComponent();
        }

        public void ClickedExp(object sender, EventArgs eventArgs) {
            Inc.BackgroundColor = Color.LightGray;
            Exp.BackgroundColor = Color.LightSkyBlue;
            IsExpense = true;
            Selected = true;
        }

        public void ClickedInc(object sender, EventArgs eventArgs)
        {
            Exp.BackgroundColor = Color.LightGray;
            Inc.BackgroundColor = Color.LightSkyBlue;
            IsExpense = false;
            Selected = true;
        }

        public void ClickedSub(object sender, EventArgs eventArgs)
        {
            if (Selected)
            {
                Navigation.PopAsync();
            }
        }
    }
}