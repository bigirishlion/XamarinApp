using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewExercise : ContentPage
    {
        private List<SearchGroup> _searchGroups;
        private SearchService _searchService;

        public ListViewExercise ()
		{
			InitializeComponent ();

            _searchService = new SearchService();

            PopupateSearches(_searchService.GetSearches());            
        }

        private void PopupateSearches(IEnumerable<Search> searches)
        {
            _searchGroups = new List<SearchGroup>()
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopupateSearches(_searchService.GetSearches(e.NewTextValue));
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            PopupateSearches(_searchService.GetSearches(search.Text));
            listView.EndRefresh();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;

            // because search groups inherits from observableModel this will refresh the UI instantly
            _searchGroups[0].Remove(search);

            _searchService.DeleteSearch(search.Id);
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }
    }
}