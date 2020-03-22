using PazumAnia.Helpers;
using PazumAnia.Services;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PazumAnia.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);

                    //if (accesstoken == null)
                    //{
                    //    Message = "Registered successfully";
                    //}

                    Settings.AccessToken = accesstoken;
                });
            }

        }
        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
