using MyExpenses.Interfaces;
using MyExpenses.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenses
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<IMessageService, MessageService>();
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
