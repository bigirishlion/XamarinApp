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
	public partial class ApplicationPropertiesGlobal : ContentPage
	{
        public ApplicationPropertiesGlobal ()
		{
			InitializeComponent ();

            var app = Application.Current as App;

            BindingContext = app;
        }
    }
}