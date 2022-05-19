using MPAccountApplication.BaseWindow;
using MPAccountApplication.View;
using MyAccountModels;
using MyAccountsBusiness.BA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MPAccountApplication.ViewModel
{
    public class StateProvinceViewModel : AbstractViewEditorModelWindow<StateProvinceViewWindow, StateProvince> 
    {
        private StateProvinceBA _stateProvinceBA;
        public StateProvinceViewModel(StateProvinceBA  stateProvinceBA)
        {
        
            this.Window.DataContext = this;
            _stateProvinceBA = stateProvinceBA;
        }

        public async override Task ShowWindowAsync()
        {
            this.Window.DataContext = this;
            this.Window.Show();

            await LoadStateProvinceAsync();
        }

 
        public override async Task SearchAsync(object o)
        {

            if (string.IsNullOrWhiteSpace(o.ToString()))
            {
                await LoadStateProvinceAsync(); 
            
            }
            else
            {
                Items.Clear();
                var items = await _stateProvinceBA.GetBySearch(o.ToString());
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
        }
 
        private async Task LoadStateProvinceAsync()
        {
            var items = await _stateProvinceBA.GetAsync();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        protected override void Bindable()
        {
             
        }


        protected async override Task Close_Command_Click_Async()
        {
            this.Window.Close(); 
        }

        protected async override Task Delete_Command_Click_Async()
        {
            var item = await _stateProvinceBA.GetByIdAsync(DataItem.Id); 
            if(item.Id > 0)
            {
                _stateProvinceBA.Delete(item);
                Items.Remove(DataItem); 
            }

        }

 


        protected async override Task Save_Command_Click_Async()
        {
           if(DataItem != null )
            {
                if(DataItem.Id == 0)
                {
                    var t = await _stateProvinceBA.SaveAsync(DataItem);
                    Items.Add(t);
                }
                else
                {
                    var t = await _stateProvinceBA.SaveAsync(DataItem); 
                }
            }
        }

        protected async override Task New_Command_Click_Async()
        {
            DataItem = null;
            DataItem = new StateProvince(); 
        }
    }
}
