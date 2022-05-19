

using MPAccountAble.BaseWindowView;
using MPAccountAble.View;
using MyAccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounts_2.ViewModel
{
    public class StateEditorViewModel : AbstractViewEditorModelWindow<StateProvinceEditorWindow, StateProvince>
    {
        public override void ShowWindow()
        {
            Window.Show(); 
        }

        protected override void Bindable()
        {
            throw new NotImplementedException();
        }

        protected override void Delete_CommandClick()
        {
            throw new NotImplementedException();
        }

        protected override void New_CommandClick()
        {
            throw new NotImplementedException();
        }

        protected override void Save_CommandClick()
        {
            throw new NotImplementedException();
        }
    }
}
