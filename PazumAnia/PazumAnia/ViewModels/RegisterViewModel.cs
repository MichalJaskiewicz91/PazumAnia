using PazumAnia.Helpers;
using PazumAnia.Services;
using PazumAnia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PazumAnia.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices apiServices = new ApiServices();
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isSuccess = await apiServices.RegisterAsync(Email, Password, ConfirmPassword);

                    Settings.Username = Username;
                    Settings.Password = Password;

                    if (isSuccess)
                    {
                        await App.Current.MainPage.DisplayAlert("Notification", "Registered successfully","Ok");
                        await Application.Current.MainPage.Navigation.PushAsync(new MainTabbedPage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Notification", "User already exists or password has not special or big letter ", "Ok");
                    }
                });  
            }
        }
    }
}
