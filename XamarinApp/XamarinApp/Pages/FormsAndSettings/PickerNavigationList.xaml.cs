using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages.FormsAndSettings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerNavigationList : ContentPage
	{
		public PickerNavigationList ()
		{
			InitializeComponent ();

            listView.ItemsSource = new List<string>()
            {
                "None",
                "Email",
                "SMS"
            };
		}

        public ListView ContactMethods { get { return listView; } }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}