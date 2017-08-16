using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages.DataAccess
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicationProperties : ContentPage
	{
		public ApplicationProperties ()
		{
			InitializeComponent ();

            if (Application.Current.Properties.ContainsKey("Title"))
                title.Text = Application.Current.Properties["Title"].ToString();

            if (Application.Current.Properties.ContainsKey("NatificationsEnabled"))
                notificationsEnabled.On = (bool)Application.Current.Properties["NatificationsEnabled"];

        }

        // This would be a good place to save the properties once they have navigated away from the page
        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //}

        private void OnChange(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties["Title"] = title.Text;
            Application.Current.Properties["NatificationsEnabled"] = notificationsEnabled.On;

            // Add if we want to save the properties right away
            //Application.Current.SavePropertiesAsync();
        }
    }
}