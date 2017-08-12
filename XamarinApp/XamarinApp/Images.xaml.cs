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
	public partial class Images : ContentPage
	{
		public Images ()
		{
			InitializeComponent ();

            // set an image UriImageSource
            //var source = new UriImageSource() { Uri = new Uri("http://lorempixel.com/1920/1080/sports/7") };
            //source.CachingEnabled = false;
            //source.CacheValidity = TimeSpan.FromHours(1);
            //image.Source = source;

            // set an embedded resource (Need to get the imageID wich is {ProjectName}.{Folder}.{FileName})
            image.Source = ImageSource.FromResource("XamarinApp.Images.background.jpg");
        }
	}
}