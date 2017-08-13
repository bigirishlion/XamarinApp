using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp.Pages.Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimpleMaster1 : ContentPage
	{
		public SimpleMaster1 ()
		{
			InitializeComponent ();
            listView.ItemsSource = new List<Contact>()
            {
                new Contact { Name = "Ezra" },
                new Contact { Name = "Lucas" }
            };
		}

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new SimpleDetail1(contact));
            listView.SelectedItem = null;

        }
    }
}