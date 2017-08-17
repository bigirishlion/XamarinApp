using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Persistence;

namespace XamarinApp.Pages.DataAccess
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;

                _name = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Status { get; set; }
        public string ImageUri { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }
        [Ignore]
        public string FullName { get { return $"{Name} {LastName}"; } }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataAccessExerciseContactBook : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Contact> _contacts;
        private bool _isDataLoaded;

        public DataAccessExerciseContactBook()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected async override void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await _connection.CreateTableAsync<Contact>();

            var contacts = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(contacts);
            listView.ItemsSource = _contacts;

            base.OnAppearing();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var page = new DataAccessExerciseContactBookDetail(new Contact());
            
            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        private async void listView_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;
            
            listView.SelectedItem = null;

            var page = new DataAccessExerciseContactBookDetail(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.Name = contact.Name;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.Blocked = contact.Blocked;
            };

            await Navigation.PushAsync(page);
        }

        async void OnDeleteContact(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
            {
                await _connection.DeleteAsync(contact);
                _contacts.Remove(contact);
            }
        }
    }
}