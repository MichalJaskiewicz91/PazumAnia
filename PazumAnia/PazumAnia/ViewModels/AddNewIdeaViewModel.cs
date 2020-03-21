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
    public class AddNewIdeaViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var idea = new Idea
                    {
                        Title = Title,
                        Description = Description,
                        Category = Category
                    };
                    await _apiServices.PostIdeasAsync(idea, Settings.AccessToken);
                });
            }
        }
    }
}
