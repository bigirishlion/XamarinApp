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
	public partial class QuotesPage : ContentPage
	{
        private string[] _quotes;
        private int _counter;

		public QuotesPage ()
		{
			InitializeComponent ();

            _quotes = new string[]
            {
                "There is nothing permanent except change.",
                "Let us sacrifice our today so that our children can have a better tomorrow.",
                "All that we see or seem is but a dream within a dream."
            };

            _counter = 0;
            quote.Text = _quotes[_counter];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (_counter == _quotes.Length -1)
                _counter = 0;
            else
                _counter++;

            quote.Text = _quotes[_counter];
        }
    }
}