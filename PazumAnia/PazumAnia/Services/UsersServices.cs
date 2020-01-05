using PazumAnia.Models;
using PazumAnia.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<Users>> GetUsersAsync()
        {
            RestClient<Users> restClient = new RestClient<Users>();
            var usersList = await restClient.GetAsync();
            return usersList;
        }
        public async Task<bool> PostUsersAsync(Users users)
        {
            RestClient<Users> restClient = new RestClient<Users>();
            var isSuccessStatusCOde = await restClient.PostAsync(users);
            return isSuccessStatusCOde;
        }
    }
}
