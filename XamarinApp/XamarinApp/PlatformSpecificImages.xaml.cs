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
	public partial class PlatformSpecificImages : ContentPage
	{
		public PlatformSpecificImages ()
		{
			InitializeComponent ();

            //btn.Image = (FileImageSource) ImageSource.FromFile(Device.OnPlatform(
            //        iOS: "clock.png",
            //        Android: "clock.png"
            //    ));
		}
	}
}