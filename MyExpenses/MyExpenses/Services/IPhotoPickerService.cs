using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Services
{
    public interface IPhotoPickerService
    {
        Task<Dictionary<string, Stream>> GetImageStreamAsync();
    }
}
