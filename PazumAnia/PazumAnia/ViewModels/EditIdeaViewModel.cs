using PazumAnia.Helpers;
using PazumAnia.Models;
using PazumAnia.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PazumAnia.ViewModels
{
    public class EditIdeaViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public Idea Idea { get; set; }
        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                    {
                        await _apiServices.PutIdeaAsync(Idea, Settings.AccessToken);
                    });

            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.DeleteIdeaAsync(Idea.Id, Settings.AccessToken);
                });

            }
        }
    }
}
