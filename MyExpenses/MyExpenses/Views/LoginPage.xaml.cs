using MyExpenses.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyExpenses.Views
{
    public partial class LoginPage : ContentPage
    {
        List<string> UsersList = new List<string>();
        int popCount = 0;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel(Navigation);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ItemSelected(object sender, EventArgs args)
        {
            if (((ListView)sender).SelectedItem == null)
                return;

            UsernameEntry.Text = lstSuggest.SelectedItem.ToString();
            ((ListView)sender).SelectedItem = null;
            lstSuggestView.IsVisible = false;
        }

        private void SuggestUserHistory(object sender, FocusEventArgs e)
        {
            if (popCount == 0)
            {
                if (Application.Current.Properties.ContainsKey("UsersList"))
                {
                    var users = Application.Current.Properties["UsersList"].ToString();
                    IList<string> usersList = users.Split(',');
                    lstSuggest.ItemsSource = usersList;
                    if (usersList.Count > 0)
                        lstSuggestView.IsVisible = true;
                    else
                        lstSuggestView.IsVisible = false;
                }
            }
        }

        private async void CloseSuggestionPopup(object sender, EventArgs e)
        {
            popCount++;
            lstSuggestView.IsVisible = false;
            await Task.Delay(100);
            UsernameEntry.Focus();
        }
    }
}