using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MPAccountApplication.BaseWindow
{
    public abstract class AbstractViewEditorModelWindow<T, E> : FrameworkElement, IViewWindow<T>, IViewEditorWindow<T, E>
       where T : new()
       where E : new()
    {
        public AbstractViewEditorModelWindow()
        {
            Window = new T();
            DataItem = new E();
            Items = new ObservableCollection<E>();
            _saveCommand = new RelayComandAsync(Save_Command_Click_Async);
            _deleteCommand = new RelayComandAsync(Delete_Command_Click_Async);
            _newCommand = new RelayComandAsync(New_Command_Click_Async);
            _closeCommand = new RelayComandAsync(Close_Command_Click_Async);

            var windowType = Window.GetType().BaseType;
            try
            {
                if (Window.GetType().BaseType == typeof(Window))
                {
                   

                }
            }
            catch(Exception ex)
            {

            }
       
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
             
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
        protected RelayComandAsync _saveCommand;
        protected RelayComandAsync _newCommand;
        protected RelayComandAsync _deleteCommand;
        protected RelayComandAsync _closeCommand;
        public RelayComandAsync SaveCommand
        {
            get { return _saveCommand; }
        }

        public RelayComandAsync NewCommand
        {
            get { return _newCommand; }
        }

        public RelayComandAsync DeleteCommand
        {
            get { return _deleteCommand; }
        }

        public RelayComandAsync CloseCommand
        {
            get { return _closeCommand; }
        }
        #endregion

        public virtual async Task SearchAsync(object o)
        {

        }
     

        public string Error => throw new NotImplementedException();



        public string this[string columnName] => throw new NotImplementedException();


      //  public abstract void ShowWindow();
        public abstract Task ShowWindowAsync();
        protected abstract Task Save_Command_Click_Async();
        protected abstract Task Delete_Command_Click_Async();
        protected abstract Task New_Command_Click_Async();
        protected abstract Task Close_Command_Click_Async();
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
