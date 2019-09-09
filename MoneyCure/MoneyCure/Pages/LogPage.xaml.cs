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
        int IoE = 0;
        List<string> Categories = new List<string>(){"cat1", "cat2", "cat3"};
        public LogPage()
        {
            InitializeComponent();
            picker.BindingContext = Categories;
        }

        public void ClickedExp(object sender, EventArgs eventArgs) {
            Exp.BackgroundColor = Color.FromRgb(100, 100, 230);
            Inc.BackgroundColor = Color.FromRgb(128, 128, 128);
            IoE = -1;
        }

        public void ClickedInc(object sender, EventArgs eventArgs)
        {
            Inc.BackgroundColor = Color.FromRgb(100, 100, 230);
            Exp.BackgroundColor = Color.FromRgb(128, 128, 128);
            IoE = 1;
        }
        async void ClickedSub(object sender, EventArgs eventArgs)
        {

        }
    }
}