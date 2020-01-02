using PazumAnia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PazumAnia.Services
{
    // Generating users' list
    public class UsersServices
    {
        public List<Users> GetUsers()
        {
            var list = new List<Users>
            {
                new Users
                {
                   Id = 1,
                   Login = "Thierry",
                   Password = "Henry"
                },
                                new Users
                {
                   Id = 2,
                   Login = "Ronaldinho",
                   Password = "Gaucho"
                },
            };
            return list;
        }
    }
}
