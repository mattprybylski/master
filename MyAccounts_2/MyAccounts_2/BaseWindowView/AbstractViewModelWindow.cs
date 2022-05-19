using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounts_2.BaseWindowView
{
    public abstract class AbstractViewModelWindow<T> : IViewWindow<T> where T : new()
    {
        public AbstractViewModelWindow()
        {
            Window = new T();
        }
        public string this[string columnName] => throw new NotImplementedException();

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public T Window { get; set; }
        public abstract void ShowWindow();

    }
}
