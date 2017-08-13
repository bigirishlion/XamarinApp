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
	public partial class PhotoGallery : ContentPage
	{
        public string ImageUri { get; set; }
        public int ImageId { get; set; }

        public PhotoGallery ()
		{
			InitializeComponent ();
            this.ImageUri = "http://lorempixel.com/1920/1080/city/";
            this.ImageId = 1;
            LoadImage();
        }

        private void prevBtn_Clicked(object sender, EventArgs e)
        {
            if (ImageId == 1)
                ImageId = 11;
            ImageId--;
            LoadImage();
        }

        private void nextBtn_Clicked(object sender, EventArgs e)
        {
            if (ImageId == 10)
                ImageId = 0;
            ImageId++;
            LoadImage();
        }

        private void LoadImage()
        {
            var source = new UriImageSource() { Uri = new Uri(string.Format("{0}{1}", ImageUri, ImageId)) };
            source.CachingEnabled = false;
            image.Source = source;
        }
    }
}