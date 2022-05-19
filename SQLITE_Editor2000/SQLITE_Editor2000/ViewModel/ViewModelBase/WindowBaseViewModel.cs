using SQLITE_Editor2000.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLITE_Editor2000.ViewModel.ViewModelBase
{
    public abstract  class WindowBaseViewModel<T, E> : FrameworkElement, IViewWindow<T, E> where E : new() where T : new()
    {
        public WindowBaseViewModel()
        {
            Window = new E();
            _newCommand = new RelayCommand(NewCommand_Click);
        }

        public ObservableCollection<T> Items { get; set; }
        private T _dataItem;
        public T DataItem
        {
            get
            {
                return _dataItem;
            }
            set
            {
                _dataItem = value;
                OnPropertyChanged("DataItem");
                OnDataItemChanged();
            }
        }

        public string Error => throw new NotImplementedException();
        public abstract void ShowWindow();
        protected abstract Task Save_Command_Click_Async();
        protected abstract Task Delete_Command_Click_Async();
        protected abstract void NewCommand_Click();
        protected abstract void CloseCommand_Click();


        #region Commands 
        protected RelayComandAsync _saveCommand;
        protected RelayCommand _newCommand;
        protected RelayComandAsync _deleteCommand;
        protected RelayCommand _closeCommand;

        public RelayComandAsync SaveCommand
        {
            get { return _saveCommand; }
        }

        public RelayCommand NewCommand
        {
            get { return _newCommand; }
        }

        public RelayComandAsync DeleteCommand
        {
            get { return _deleteCommand; }
        }

        public RelayCommand CloseCommand
        {
            get { return _closeCommand; }
        }

        public E Window { get; set; }

        public string this[string columnName] => throw new NotImplementedException();
        #endregion


        protected virtual void OnDataItemChanged()
        {

        }

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
