using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccountModels
{
    public interface IModelBase //: INotifyPropertyChanged
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
