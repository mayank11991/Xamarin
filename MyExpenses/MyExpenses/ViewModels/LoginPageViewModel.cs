using MyExpenses.Interfaces;
using MyExpenses.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly IMessageService _messageService;
        public INavigation Navigation { get; set; }
        public LoginPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            _messageService = DependencyService.Get<IMessageService>();
            Username = string.Empty;
            Password = string.Empty;
            //CheckMandatoryFields();
            IsLoginEnable = false;
        }

        #region Properties
        string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                CheckMandatoryFields();
            }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                CheckMandatoryFields();
            }
        }

        bool _isLoginEnable;
        public bool IsLoginEnable
        {
            get { return _isLoginEnable; }
            set
            {
                _isLoginEnable = value;
                OnPropertyChanged(nameof(IsLoginEnable));
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand => new Command(async i =>
        {
            try
            {
                if (Password.ToLower() == "password")
                {
                    SaveUsersLocally();
                    await Navigation.PushAsync(new DashbaordPage());
                }
                else
                {
                    await _messageService.ShowAsync("Report Writer!", "Invalid Password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        });

        #endregion

        private void CheckMandatoryFields()
        {
            try
            {
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                {
                    IsLoginEnable = true;
                }
                else
                {
                    IsLoginEnable = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void SaveUsersLocally()
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("UsersList"))
                {
                    var users = Application.Current.Properties["UsersList"].ToString();
                    IList<string> usersList = users.Split(',');
                    if (!usersList.Contains(Username.ToLower()))
                    {
                        Application.Current.Properties["UsersList"] += "," + Username;
                        await Application.Current.SavePropertiesAsync();
                    }
                }
                else
                {
                    Application.Current.Properties["UsersList"] = Username;
                    await Application.Current.SavePropertiesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
