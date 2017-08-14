using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages.FormsAndSettings
{
    public class ContactMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Picker : ContentPage
    {

        private IEnumerable<ContactMethod> _contactMethods;

        public Picker()
        {
            InitializeComponent();

            _contactMethods = GetContactMethods();

            foreach (var method in _contactMethods)
                contactMethods.Items.Add(method.Name);
        }

        private void contactMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = contactMethods.Items[contactMethods.SelectedIndex];
            var method = _contactMethods.Single(x => x.Name == name);
            DisplayAlert("Selected", method.Name, "OK");
        }

        public IEnumerable<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>()
            {
                new ContactMethod {Id = 1, Name = "SMS"},
                new ContactMethod {Id = 1, Name = "Email"}
            };
        }
    }
}