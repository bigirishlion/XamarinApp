using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Extensions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasicEntryCell : ViewCell
    {
        private static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(BasicEntryCell));
        private static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(string), typeof(BasicEntryCell));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public BasicEntryCell ()
		{
			InitializeComponent ();

            BindingContext = this;
		}
	}
}