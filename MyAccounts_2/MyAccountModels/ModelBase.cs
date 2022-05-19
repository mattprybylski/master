using MyAccountModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDataField.DataField;

namespace MyAccountModels
{
    
    public abstract class ModelBase :   IModelBase, INotifyPropertyChanged
    {
        public ModelBase()
        {
            
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

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
