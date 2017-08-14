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
    public partial class NavigationExercise : TabbedPage
    {
        private ActivityService _activityService;

        public NavigationExercise()
        {
            InitializeComponent();
        }
    }
}