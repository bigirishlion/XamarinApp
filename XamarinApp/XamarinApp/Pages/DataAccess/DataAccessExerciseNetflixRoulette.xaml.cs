using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.Pages.DataAccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataAccessExerciseNetflixRoulette : ContentPage
    {
        private MovieService _movieService;

        public DataAccessExerciseNetflixRoulette()
        {
            InitializeComponent();

            _movieService = new MovieService();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 5)
            {
                resultsLabel.IsVisible = false;
                listView.BeginRefresh();
                try
                {
                    var movies = await _movieService.FindMoviesByActor(e.NewTextValue);
                    if (movies.Count() == 0)
                        resultsLabel.IsVisible = true;

                    listView.ItemsSource = movies;
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Could not diplay the list of movies", "OK");
                }
                listView.EndRefresh();
            }
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;

            var movie = e.SelectedItem as Movie;
            await Navigation.PushAsync(new DataAccessExerciseNetflixRouletteDetail(movie));
            listView.SelectedItem = null;
        }
    }
}