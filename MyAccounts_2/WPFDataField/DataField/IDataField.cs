using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDataField.DataField
{
    public interface IDataField<T>
    {
        bool IsDirty
        {
            get;
            set;
        }

        T Value
        {
            get;
            set;
        }
 

        string DataFieldName
        {
            get;
            set;
        }

        int DataFieldID
        {
            get;
            set;
        }


    }

}
