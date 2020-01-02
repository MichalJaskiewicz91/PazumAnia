using PazumAnia.Models;
using PazumAnia.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PazumAnia.ViewModels
{
    public class MainViewModel
    {
        private List<Users> _usersList;

        public List<Users> UsersList { get => _usersList; set => _usersList = value; }
        public MainViewModel()
        {
            var userServices = new UsersServices();
            UsersList = userServices.GetUsers();

        }
    }
}
