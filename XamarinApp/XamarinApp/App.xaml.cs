using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp.Pages.Navigation;
using XamarinApp.Pages.FormsAndSettings;
using XamarinApp.Pages.DataAccess;

namespace XamarinApp
{
    public partial class App : Application
    {
        private string TitleKey = "Title";
        private string NotificationsKey = "NotificationsEnabled";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new XamarinApp.Pages.DataAccess.DataAccessExerciseContactBook() );
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Current.Properties[TitleKey].ToString();

                return "";
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }

        public bool NotificationsEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsKey))
                    return (bool)Current.Properties[NotificationsKey];

                return false;
            }
            set
            {
                Properties[NotificationsKey] = value;
            }
        }
    }
}
