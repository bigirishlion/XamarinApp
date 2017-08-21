using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Pages.MVVM.Persistence;
using XamarinApp.Pages.MVVM.ViewModels;
using XamarinApp.Persistence;

namespace XamarinApp.Pages.MVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MVVMExercise : ContentPage
    {
        public MVVMExercise()
        {
            var contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ContactsPageViewModel(contactStore, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }

        public ContactsPageViewModel ViewModel
        {
            get { return BindingContext as ContactsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}