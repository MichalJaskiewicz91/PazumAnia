using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PazumAnia
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Succes", "We have handled the click event", "Great!");
        }
    }
}
