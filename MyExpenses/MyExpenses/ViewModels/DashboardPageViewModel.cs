using MyExpenses.Interfaces;
using MyExpenses.Models;
using MyExpenses.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class DashboardPageViewModel : INotifyPropertyChanged
    {
        private readonly IMessageService _messageService;

        public DashboardPageViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            DescriptionLabel = "Total expense claim is  £0.";
            ImageSOurce = "upload_image";
            Expenses = new ObservableCollection<Expense> {
            new Expense{ Title ="Fuel",Amount=string.Empty},
            new Expense{ Title ="Parking",Amount=string.Empty},
            new Expense{ Title ="Food",Amount=string.Empty},
            };
            TextChangedCommand = new Command(CompletedCommandExecutedAsync);
        }

        #region Properties

        ImageSource _imageSOurce;
        public ImageSource ImageSOurce
        {
            get { return _imageSOurce; }
            set
            {
                _imageSOurce = value;
                OnPropertyChanged(nameof(ImageSOurce));
            }
        }

        public ObservableCollection<Expense> Expenses { get; }

        string _descriptionLabel;
        public string DescriptionLabel
        {
            get { return _descriptionLabel; }
            set
            {
                _descriptionLabel = value;
                OnPropertyChanged(nameof(DescriptionLabel));
            }
        }

        #endregion

        #region Commands
        public ICommand UploadImage => new Command(async () =>
        {
            try
            {
                Dictionary<string, Stream> dic = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                Stream stream;
                foreach (KeyValuePair<string, Stream> currentImage in dic)
                {
                    stream = currentImage.Value;
                    ImageSOurce = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        });
        public ICommand TextChangedCommand { get; protected set; }

        #endregion
        private void CompletedCommandExecutedAsync(object param)
        {
            try
            {
                decimal totalExpense = Expenses.Sum(x => x.Amount == "" ? 0 : decimal.Parse(x.Amount));
                var highestExpense = Expenses.OrderBy(y => y.Amount == "" ? 0 : decimal.Parse(y.Amount)).LastOrDefault();
                DescriptionLabel = "Total expense claim is  £" + totalExpense + ". The highest category was " + highestExpense.Title;
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
