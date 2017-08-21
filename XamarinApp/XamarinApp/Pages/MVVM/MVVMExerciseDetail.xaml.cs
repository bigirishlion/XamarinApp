using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Pages.MVVM.ViewModels;

namespace XamarinApp.Pages.MVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MVVMExerciseDetail : ContentPage
    {
        public MVVMExerciseDetail(ContactDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}