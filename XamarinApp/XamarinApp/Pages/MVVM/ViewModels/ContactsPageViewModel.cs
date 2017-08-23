using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Pages.MVVM.Models;

namespace XamarinApp.Pages.MVVM.ViewModels
{
    public class ContactsPageViewModel : BaseViewModel
    {
        private ContactViewModel _selectedContact;
        private IContactStore _contactStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        // Note that I've initialized Contacts to a new ObservableCollection 
        // here, even though we set it again later after loading contacts. 
        // This is required because in ContactsPage we've bound list view's ItemSource
        // to this property. Without this initialization, binding will throw a
        // NullReferenceException. 
        public ObservableCollection<ContactViewModel> Contacts { get; private set; }
            = new ObservableCollection<ContactViewModel>();

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }
        public ICommand SelectContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactsPageViewModel(IContactStore contactStore, IPageService pageService)
        {
            _contactStore = contactStore;
            _pageService = pageService;

            // Because LoadData is an async method and returns Task, we cannot
            // pass its name as an Action to the constructor of the Command. 
            // So, we need to define an inline function using a lambda expression
            // and manually call it using await. 
            LoadDataCommand = new Command(async () => await LoadData());
            AddContactCommand = new Command(async () => await AddContact());
            SelectContactCommand = new Command<ContactViewModel>(async c => await SelectContact(c));
            DeleteContactCommand = new Command<ContactViewModel>(async c => await DeleteContact(c));

            // Subscribe to events 
            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>
                (this, Events.ContactAdded, OnContactAdded);

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>
            (this, Events.ContactUpdated, OnContactUpdated);
        }

        private void OnContactAdded(ContactDetailViewModel source, Contact contact)
        {
            Contacts.Add(new ContactViewModel(contact));
        }

        private void OnContactUpdated(ContactDetailViewModel source, Contact contact)
        {
            // Here we need to find the corresponding Contact object in our 
            // ObservableCollection first. 
            var contactInList = Contacts.Single(c => c.Id == contact.Id);

            contactInList.Id = contact.Id;
            contactInList.FirstName = contact.FirstName;
            contactInList.LastName = contact.LastName;
            contactInList.Phone = contact.Phone;
            contactInList.Email = contact.Email;
            contactInList.IsBlocked = contact.IsBlocked;
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            // Our contact store works with Contact objects. In this view model, 
            // we work with ContactViewModel objects. So, here I've called 
            // LINQ Select() extension method to map these Contact objects to
            // ContactViewModel. 
            var contacts = await _contactStore.GetContactsAsync();

            foreach (var c in contacts)
                Contacts.Add(new ContactViewModel(c));
        }

        private async Task AddContact()
        {
            await _pageService.PushAsync(new MVVMExerciseDetail(new ContactViewModel()));
        }

        private async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            await _pageService.PushAsync(new MVVMExerciseDetail(contact));
        }

        private async Task DeleteContact(ContactViewModel contactViewModel)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {contactViewModel.FullName}?", "Yes", "No"))
            {
                Contacts.Remove(contactViewModel);

                // We're working with ContactViewModel objects on this page. 
                // But to delete a contact, we need a Contact object. Here
                // we're getting the Contact again from the database. Another
                // solution would be to store the Contact objects we initially 
                // fetch. But this would require additional memory and as the 
                // number of contacts grows, it can take unnecessary amount of
                // memory on the device. So, I prefer to get the contact explicitly
                // here. 
                var contact = await _contactStore.GetContact(contactViewModel.Id);
                await _contactStore.DeleteContact(contact);
            }
        }
    }
}
