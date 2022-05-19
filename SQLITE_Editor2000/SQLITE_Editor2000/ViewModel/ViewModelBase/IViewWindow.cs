using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITE_Editor2000.ViewModel.ViewModelBase
{
    public interface IViewWindow<T, E> : INotifyPropertyChanged, IDataErrorInfo where T : new() where E : new()
    {

        E Window { get; set; }
        ObservableCollection<T> Items { get; set; }
        T DataItem { get; set; }
        void ShowWindow();

    }
}
