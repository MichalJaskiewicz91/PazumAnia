using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PazumAnia.DataBase;

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
        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Succes", "We have handled the click event", "Great!");
            App.Current.MainPage = new NavigationPage(new MainTabbedPage());
            //MySqlDatabase mySqlDatabase = new MySqlDatabase();
            //mySqlDataReader = mySqlDatabase.ReadFromDB("SELECT * FROM visits ORDER BY RAND() LIMIT 1");
        }

    }
}