using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.Pages.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationExerciseList : ContentPage
    {
        private ActivityService _activityService;

        public NavigationExerciseList()
        {
            InitializeComponent();

            _activityService = new ActivityService();

            listView.ItemsSource = _activityService.GetActivities();
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var activity = e.SelectedItem as Activity;
            await Navigation.PushAsync(new NavigationPage(new NavigationExerciseDetail(activity)));
            listView.SelectedItem = null;
        }
    }
}