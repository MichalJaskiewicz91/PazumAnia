using PazumAnia.Models;
using PazumAnia.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PazumAnia.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Users> _usersList;
        private Users _selectedUser = new Users();

        public event PropertyChangedEventHandler PropertyChanged;

        public Users SelectedUser { get => _selectedUser; set => _selectedUser = value; }
        public Command PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var usersServices = new UsersServices();
                    await usersServices.PostUsersAsync(_selectedUser);


                });
            }
        }

        public List<Users> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            //var userServices = new UsersServices();
            //UsersList = userServices.GetUsers();
            InitializeDataAsync();
        }
        public async Task InitializeDataAsync()
        {
            var userServices = new UsersServices();
            UsersList = await userServices.GetUsersAsync();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
