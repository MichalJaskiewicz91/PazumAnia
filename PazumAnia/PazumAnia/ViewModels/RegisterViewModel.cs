using PazumAnia.Helpers;
using PazumAnia.Services;
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
                        Message = "Registered successfully";
                    }
                    else
                    {
                        Message = "Retry later";
                    }
                });  
            }
        }
    }
}
