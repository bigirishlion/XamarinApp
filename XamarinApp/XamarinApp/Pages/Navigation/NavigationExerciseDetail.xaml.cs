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
    public partial class NavigationExerciseDetail : ContentPage
    {
        private UserService _userService;

        public NavigationExerciseDetail(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException();

            _userService = new UserService();
            var user = _userService.GetUserProfile(activity.UserId);

            BindingContext = user;

            InitializeComponent();
        }
    }
}