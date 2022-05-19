using MPAccountApplication.BaseWindow;
using MPAccountApplication.View;
using MyAccountModels;
using MyAccountsBusiness.BA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccountApplication.ViewModel
{
    public class AccountViewModel : AbstractViewEditorModelWindow<AccountViewWindow, Account>
    {
        private readonly AccountBA _accountBA; 
        public AccountViewModel()
        {
            _accountBA = new AccountBA();
        }

        public async override Task ShowWindowAsync()
        {
            Window.Show();
             Window.DataContext = this;
            var items = await _accountBA.GetAsync();
            items.ForEach(x => Items.Add(x)); 
            
        }

        protected override void Bindable()
        {
         
        }

        protected async override Task Close_Command_Click_Async()
        {
            this.Window.Close();
        }

        protected async    override Task Delete_Command_Click_Async()
        {
            var item = await _accountBA.GetByIdAsync(DataItem.Id);
            if (item.Id > 0)
            {
                _accountBA.Delete(item);
                Items.Remove(DataItem);
            }
        }

        protected async override Task New_Command_Click_Async()
        {
            DataItem = null;
            DataItem = new Account();
        }

        protected async override Task Save_Command_Click_Async()
        {
            if (DataItem != null)
            {
                if (DataItem.Id == 0)
                {
                    var t = await _accountBA.SaveAsync(DataItem);
                    Items.Add(t);
                }
                else
                {
                    var t = await _accountBA.SaveAsync(DataItem);
                }
            }
        }
    }
}
