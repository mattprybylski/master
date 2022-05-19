using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccountApplication.BaseWindow
{
    public interface IViewEditorWindow<T, E> :  IViewEditorBase, IViewWindow<T> where T : new() where E : new()
    {

        T Window { get; set; }
        ObservableCollection<E> Items { get; set; }
        E DataItem { get; set; }

    

    }

}
