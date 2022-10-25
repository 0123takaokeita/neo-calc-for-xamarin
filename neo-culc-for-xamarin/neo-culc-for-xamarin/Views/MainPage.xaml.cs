using Xamarin.Forms;
using neo_culc_for_xamarin.ViewModels;
using neo_culc_for_xamarin.Models;

namespace neo_culc_for_xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
