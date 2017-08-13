using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lists : ContentPage
	{

        private ObservableCollection<Contact> _contacts;

		public Lists ()
		{
			InitializeComponent ();

            _contacts = new ObservableCollection<Contact>()
            {
                new Contact {Name = "Ezra", ImageUri = "http://lorempixel.com/100/100/people/1/"},
                new Contact {Name = "Lucas", ImageUri = "http://lorempixel.com/100/100/people/2/", Status = "Yo What Up!?"}
            };

            listView.ItemsSource = _contacts;

            //listView.ItemsSource = GetContacts();

            //listView.ItemsSource = new List<ContactGroup>()
            //{
            //    new ContactGroup("E", "E")
            //    {
            //        new Contact {Name = "Ezra", ImageUri = "http://lorempixel.com/100/100/people/1/"}
            //    },
            //    new ContactGroup("L", "L")
            //    {
            //        new Contact {Name = "Ezra", ImageUri = "http://lorempixel.com/100/100/people/2/", Status = "Yo What Up!?"}
            //    }
            //};
        }
        
        //private IEnumerable<Contact> GetContacts(string searchString = null)
        //{
        //    //_contacts = new List<Contact>()
        //    //{
        //    //    new Contact {Name = "Ezra", ImageUri = "http://lorempixel.com/100/100/people/1/"},
        //    //    new Contact {Name = "Lucas", ImageUri = "http://lorempixel.com/100/100/people/2/", Status = "Yo What Up!?"}
        //    //};

        //    // Search
        //    //if (string.IsNullOrWhiteSpace(searchString))
        //    //{
        //    //    return contacts;
        //    //}

        //    //return contacts.Where(x => x.Name.StartsWith(searchString));
        //}

        //private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    listView.ItemsSource = GetContacts(e.NewTextValue);
        //}

        private void Call_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        // Adding selected events
        //private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    //var contact = e.SelectedItem as Contact;
        //    //DisplayAlert("Selected", contact.Name, "OK");
        //    listView.SelectedItem = null;
        //}

        //private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var contact = e.Item as Contact;
        //    DisplayAlert("Tapped", contact.Name, "OK");
        //}

        //private void listView_Refreshing(object sender, EventArgs e)
        //{
        //    listView.ItemsSource = GetContacts();

        //    listView.EndRefresh();
        //}
    }
}