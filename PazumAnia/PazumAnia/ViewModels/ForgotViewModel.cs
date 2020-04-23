using PazumAnia.Models;
using PazumAnia.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PazumAnia.ViewModels
{
    public class ForgotViewModel : INotifyPropertyChanged
    {
        public string Email { get; set; }
        ApiServices apiServices = new ApiServices();
        public ResetPassword resetPassword { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ResetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await apiServices.ResetAsync(Email);

                    if (isSuccess)
                    {
                        await App.Current.MainPage.DisplayAlert("Notification", "Password has been sent successfully , check your mailbox", "Ok");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Notification", "Password has not been sent, this address does not exist ", "Ok");
                    }
                });
            }

        }

    }
}
