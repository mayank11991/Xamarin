using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Interfaces
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message);
    }
}
