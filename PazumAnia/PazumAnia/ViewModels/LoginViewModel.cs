using PazumAnia.Helpers;
using PazumAnia.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PazumAnia.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private ApiServices _apiServices = new ApiServices();
        private string _successMessage;

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);
                    if (accesstoken == null)
                    {
                        SuccessMessage = "The user name or password is incorrect";
                    }
                    else
                    {
                        SuccessMessage = "Login successfully";
                    }

                    Settings.AccessToken = accesstoken;
                });
            }

        }
        public string SuccessMessage
        {
            get
            { return _successMessage; }
            set
            {
                _successMessage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
