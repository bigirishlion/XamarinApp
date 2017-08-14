using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popups : ContentPage
    {
        public Popups()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            //var response = await DisplayAlert("Choose", "Are you Sure?", "Yes", "No");
            //await DisplayAlert("You Chose", response.ToString(), "OK");

            var response = await DisplayActionSheet("Options", "Cancel", "Delete", "Copy Link", "Email", "Message");
            await DisplayAlert("You Chose", response, "OK");
        }
    }
}