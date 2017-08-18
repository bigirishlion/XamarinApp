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
    public partial class DataAccessExerciseNetflixRouletteDetail : ContentPage
    {
        MovieService _movieService = new MovieService();
        private Movie _movie;

        public DataAccessExerciseNetflixRouletteDetail(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            InitializeComponent();

            _movie = movie;
        }

        protected async override void OnAppearing()
        {
            var movie = await _movieService.GetMovie(_movie.ShowTitle);
            BindingContext = movie;
            base.OnAppearing();
        }
    }
}