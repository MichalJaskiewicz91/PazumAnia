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
        #region Fields
        private Users _selectedUser = new Users();
        private List<Users> _usersList;
        private bool _isBusy;
        private string _statusMessage;
        #endregion
        // Properties represent state of the view
        #region Properties
        public Users SelectedUser { get => _selectedUser; set => _selectedUser = value; }
        public List<Users> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }
        public Command PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    var usersServices = new UsersServices();
                    var isSuccess = await usersServices.PostUsersAsync(_selectedUser);

                    if (isSuccess == true)
                    {
                        StatusMessage = "Post Users has done successfully!";
                    }
                    else
                    {
                        StatusMessage = "Operation Post failed";
                    }

                    IsBusy = false;
                });
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructos
        // Constructors
        public MainViewModel()
        {
            //var userServices = new UsersServices();
            //UsersList = userServices.GetUsers();
            InitializeDataAsync();
        }
        #endregion
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        // Method implement the logic behind the view
        #region Methods
        public async Task InitializeDataAsync()
        {
            var userServices = new UsersServices();
            UsersList = await userServices.GetUsersAsync();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
