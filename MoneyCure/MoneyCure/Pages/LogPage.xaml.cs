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
        bool IsExpense = false;
        public LogPage()
        {
            InitializeComponent();
        }

        public void ClickedExp(object sender, EventArgs eventArgs) {
            Exp.BackgroundColor = Color.Blue;
            Inc.BackgroundColor = Color.LightGray;
            IsExpense = !IsExpense;
        }

        public void ClickedInc(object sender, EventArgs eventArgs)
        {
            Inc.BackgroundColor = Color.Blue;
            Exp.BackgroundColor = Color.LightGray;
            IsExpense = !IsExpense;
        }

        public void ClickedSub(object sender, EventArgs eventArgs) {


        }

    }
}