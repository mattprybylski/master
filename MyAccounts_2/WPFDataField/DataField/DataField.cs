using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDataField.DataField
{
        
    public class DataField<T> : EventArgs, IDataField<T>, INotifyPropertyChanged
    {

        //public delegate void ValueChangedEvent(object sender, EventArgs e);


        /// </summary>
        private T value;
        private string errormessage;

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Value"));
            }
        }

        public DataFieldIDs DataFieldID
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public bool IsDirty
        {
            get;
            set;
        }

        #region IEditableObject Members

        public void BeginEdit()
        {

        }

        public void CancelEdit()
        {

        }

        public void EndEdit()
        {

        }

        #endregion


        public override string ToString()
        {
            return this.Value.ToString(); 
        }


        public string DataFieldName
        {
            get;
            set;
        }

        int IDataField<T>.DataFieldID
        {
            get;
            set;
        }
    }


}
