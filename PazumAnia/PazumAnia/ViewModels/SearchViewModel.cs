using PazumAnia.Helpers;
using PazumAnia.Models;
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
    public class SearchViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<Idea> _ideas;

        public string Keyword { get; set; }

        public List<Idea> Ideas
        {
            get { return _ideas; }
            set
            {
                _ideas = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Ideas = await _apiServices.SearchIdeasAsync(Keyword, Settings.AccessToken);
                });

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
