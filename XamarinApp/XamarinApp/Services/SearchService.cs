using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    class SearchService
    {
        public List<Search> _searches = new List<Search>
        {
            new Search {Id = 1, Location = "San Francisco, CA", CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(5)},
            new Search {Id = 2, Location = "New York, NY", CheckIn = DateTime.Now, CheckOut = DateTime.Now.AddDays(5)}
        };

        public IEnumerable<Search> GetSearches(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return _searches;
            }

            return _searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        public void DeleteSearch(int searchId)
        {
            var search = _searches.FirstOrDefault(x => x.Id == searchId);
            _searches.Remove(search);
        }
    }
}
