using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MPAccountApplication.BaseWindow
{
    public abstract class AbstractViewModelWindow<E> : FrameworkElement, IViewWindow<E>
       where E : new()
    {
        public AbstractViewModelWindow()
        {
            Window = new E();
        }

        public E Window { get; set; }
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


        public abstract Task ShowWindowAsync();
     
    }
}
