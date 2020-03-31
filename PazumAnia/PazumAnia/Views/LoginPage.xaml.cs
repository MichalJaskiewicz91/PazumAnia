using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PazumAnia.DataBase;
using PazumAnia.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PazumAnia.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        MySqlDataReader mySqlDataReader;
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Registration_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPageAnia());
        }


        //public static async Task DisplayAlert(string notification, string description, string ok)
        //{

        //    await DisplayAlert(notification, description, ok);
        //}
        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new NavigationPage(new MainTabbedPage());
        //    //MySqlDatabase mySqlDatabase = new MySqlDatabase();
        //    //mySqlDataReader = mySqlDatabase.ReadFromDB("SELECT * FROM visits ORDER BY RAND() LIMIT 1");
        //}

        //private void GoToRegisterPage(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new NavigationPage(new RegisterPageAnia());
        //}
    }
}