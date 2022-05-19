using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WPFDataField.DataField
{
    public static class _DataFieldCreator
    {
        public static IDataField<T> CreateField<T>(this IDataFieldOwner o, IDataField<T> field, string fieldid)
        {
            field = new DataField<T>();
            field.Value = default(T);
            //field. = fieldid;
            return field;
        }

        public static IDataField<T> CreateField<T>(this IDataFieldOwner o, IDataField<T> field, int fieldid)
        {
            field = new DataField<T>();
            field.Value = default(T);
           // field.DataFieldID = (DataFieldIDs) fieldid;
            return field;
        }


        public static IDataField<T> CreateField<T>(this IDataFieldOwner o, IDataField<T> field, string fieldname, int fieldid)
        {
            field = new DataField<T>();
            field.Value = default(T);
            // field.DataFieldID = (DataFieldIDs) fieldid;
            field.DataFieldName = fieldname;
            field.DataFieldID = fieldid; 
            return field;
        }

    }

}
