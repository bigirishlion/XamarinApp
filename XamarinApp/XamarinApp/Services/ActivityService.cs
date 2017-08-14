using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    class ActivityService
    {
        public IEnumerable<Activity> GetActivities()
        {
            return new List<Activity>()
            {
                new Activity {Description = "Ezra is following you", UserId = 1},
                new Activity {Description = "Lucas stopped follwing you", UserId = 2},
                new Activity {Description = "Rachelle stopped follwing you", UserId = 3},
                new Activity {Description = "Kellen stopped follwing you", UserId = 4}
            };
        }
    }
}
