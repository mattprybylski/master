using MyAccounts_2.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounts_2.BaseWindowView
{
    public abstract class AbstractViewEditorModelWindow<T, E> :  IViewWindow<T>, IViewEditorWindow<T, E>
       where T : new()
       where E : new()
    {
        public AbstractViewEditorModelWindow()
        {
            Window = new T();
            DataItem = new E();
            Items = new ObservableCollection<E>();
        }
        public T Window { get; set; }

        private E _dataItem;
        private ObservableCollection<E> _items;
        public E DataItem
        {
            get
            {
                return _dataItem;
            }
            set
            {
                _dataItem = value;
                OnPropertyChanged("DataItem");
                Bindable();
            }
        }

        public ObservableCollection<E> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
        #region Commands 
        protected RelayCommand _saveCommand;
        protected RelayCommand _newCommand;
        protected RelayCommand _deleteCommand;
        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public RelayCommand NewCommand
        {
            get { return _newCommand; }
        }

        public RelayCommand DeleteCommand
        {
            get { return _deleteCommand; }
        }
        #endregion


        public string Error => throw new NotImplementedException();



        public string this[string columnName] => throw new NotImplementedException();

        public abstract void ShowWindow();
        protected abstract void Save_CommandClick();
        protected abstract void Delete_CommandClick();
        protected abstract void New_CommandClick();
        protected abstract void Bindable();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
