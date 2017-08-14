using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class UserService
    {
        public List<User> _users = new List<User>()
        {
            new User {Id = 1, Name = "Ezra", Description = "My Name is Ezra"},
            new User {Id = 2, Name = "Lucas", Description = "My Name is Lucas "},
            new User {Id = 3, Name = "Rachelle", Description = "My Name is Rachelle"},
            new User {Id = 4, Name = "Kellen", Description = "My Name is Kellen "}
        };

        public User GetUserProfile(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
