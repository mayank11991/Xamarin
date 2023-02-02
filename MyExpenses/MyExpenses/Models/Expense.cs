using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyExpenses.Models
{
    public class Expense
    {
        public string Title { set; get; }
        public string Amount { set; get; }

        //private string _title;
        //public string Title
        //{
        //    get => _title;
        //    set
        //    {
        //        if (_title != value)
        //        {
        //            _title = value;
        //            OnPropertyChanged(nameof(Title));
        //        }
        //    }
        //}

        //private string _amount;
        //public string Amount
        //{
        //    get => _amount;
        //    set
        //    {
        //        if (_amount != value)
        //        {
        //            _amount = value;
        //            OnPropertyChanged(nameof(Amount));
        //        }
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        //    }
        //}
    }
}
