//using MPAccountApplication.BaseWindow;
//using MPAccountApplication.View;
//using MyAccountModels;
//using MyAccountsBusiness.BA;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MPAccountApplication.ViewModel
//{
//    public class BillExpenseTypeViewModel : AbstractViewEditorModelWindow<ExpenseTypeViewWindow, BilllExpenseType>
//    {
//        private readonly BillExpenseTypeBA _expenseTypeBA;
//        public BillExpenseTypeViewModel( )
//        {
//            _expenseTypeBA = new BillExpenseTypeBA(); 
            
//        }
//        public async override Task ShowWindowAsync()
//        {
//            this.Window.DataContext = this;
//            this.Window.Show();

//            await LoadItemsAsync();
//        }


 

//        private async Task LoadItemsAsync()
//        {
//            Items = new System.Collections.ObjectModel.ObservableCollection<BilllExpenseType>(); 
//            var items = await _expenseTypeBA.GetAsync();
//            items.ForEach(x => Items.Add(x)); 

//        }

//        protected override void Bindable()
//        {
        
//        }

//        protected async override Task Close_Command_Click_Async()
//        {
//            this.Window.Close();
//        }

//        protected async override Task Delete_Command_Click_Async()
//        {
//            var item = await _expenseTypeBA.GetByIdAsync(DataItem.Id);
//            if (item.Id > 0)
//            {
//                _expenseTypeBA.Delete(item);
//                Items.Remove(DataItem);
//            }
//        }

//        protected async override Task New_Command_Click_Async()
//        {
//            DataItem = null;
//            DataItem = new BilllExpenseType(); 
//        }

  
//        protected async override Task Save_Command_Click_Async()
//        {
//            if (DataItem != null)
//            {
//                var t = await _expenseTypeBA.SaveAsync(DataItem);
//                Items.Add(t);
//            }
//        }
//    }
//}
