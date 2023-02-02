using MyExpenses.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashbaordPage : ContentPage
    {
        public DashbaordPage()
        {
            InitializeComponent();
            BindingContext = new DashboardPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}