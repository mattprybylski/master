using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccountAble.BaseWindowView
{
    public interface IViewWindow<T> : INotifyPropertyChanged, IDataErrorInfo where T : new()
    {
        void ShowWindow();
    }
}
