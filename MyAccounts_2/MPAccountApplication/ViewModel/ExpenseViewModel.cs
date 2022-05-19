//using MPAccountApplication.BaseWindow;
//using MPAccountApplication.View;
//using MyAccountModels;
//using MyAccountModels.Common;
//using MyAccountsBusiness.BA;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace MPAccountApplication.ViewModel
//{
//    public class ExpenseViewModel : AbstractViewEditorModelWindow<ExpenseViewWindow, Expense>
//    {

//        #region Properties
//        public ExpenseDuration ExpenseDuration
//        {
//            get { return (ExpenseDuration)this.GetValue(ExpenseDurationProperty); }
//            set
//            {
//                this.SetValue(ExpenseDurationProperty, value);
//                DataItem.ExpenseDuration = value; 
//            }
//        }
//        public static readonly DependencyProperty ExpenseDurationProperty = DependencyProperty.Register(
//          "ExpenseDuration", typeof(ExpenseDuration), typeof(ExpenseViewModel), new PropertyMetadata(ExpenseDuration.Monthly));

//        public BilllExpenseType ExpenseType
//        {
//            get { return (BilllExpenseType)this.GetValue(ExpenseTypeProperty); }
//            set
//            {
//                this.SetValue(ExpenseTypeProperty, value);
//                this.DataItem.ExpenseType = ExpenseType;
//            }
//        }
//        public static readonly DependencyProperty ExpenseTypeProperty = DependencyProperty.Register(
//          "ExpenseType", typeof(BilllExpenseType), typeof(ExpenseViewModel), new PropertyMetadata(null));

//        private readonly BillExpenseTypeBA _expenseTypeBA;
//        private readonly ExpenseBA _expenseBA;
//        private ObservableCollection<BilllExpenseType> _expenseTypes;
//        public ObservableCollection<BilllExpenseType> ExpenseTypes
//        {
//            get { return _expenseTypes; }
//            set
//            {
//                _expenseTypes = value;
//                OnPropertyChanged("ExpenseTypes");
//            }
//        }
//        #endregion

//        public ExpenseViewModel()
//        {

//            _expenseBA = new ExpenseBA();
//            _expenseTypeBA = new BillExpenseTypeBA(); 

//            this.Window.DataContext = this; 

          
//        }
//        public  async override Task ShowWindowAsync()
//        {
//            ExpenseTypes = new ObservableCollection<BilllExpenseType>();
//            var items  = await _expenseTypeBA.GetAsync();

//            items.ForEach(x => ExpenseTypes.Add(x)); 
//            await LoadStateProvinceAsync(); 
//            this.Window.Show(); 
//        }

//        protected override void Bindable()
//        {
//            if(DataItem != null && DataItem.Id > 0)
//            {
//                ExpenseDuration      = DataItem.ExpenseDuration;
//                ExpenseType          = ExpenseTypes.FirstOrDefault(x => x.Id == DataItem.ExpenseTypeId);
           
//            }
            
//        }

//        private async Task LoadStateProvinceAsync()
//        {

//            var items = await _expenseBA.GetAsync();

//            foreach (var item in items)
//            {
//                Items.Add(item);
//            }
//        }

//        protected async override Task Close_Command_Click_Async()
//        {
//            this.Window.Close();
//        }

//        protected async override Task Delete_Command_Click_Async()
//        {
//            var item = await _expenseBA.GetByIdAsync(DataItem.Id);
//            if (item.Id > 0)
//            {
//                _expenseBA.Delete(item);
//                Items.Remove(DataItem);
//            }
//        }

//        protected async override Task New_Command_Click_Async()
//        {
//            DataItem = null;
//            DataItem = new Expense(); 
//        }

//        protected async override Task Save_Command_Click_Async()
//        {
//            DataItem.ExpenseDuration = ExpenseDuration; 
//          if(DataItem.ExpenseType == null || DataItem.ExpenseType.Id == 0)
//            {
//                DataItem.ExpenseType = ExpenseType; 
//            }

//            if (DataItem != null)
//            {
//                if (DataItem.Id == 0)
//                {
//                    var t = await _expenseBA.SaveAsync(DataItem);
//                    Items.Add(t);
//                }
//                else
//                {
//                    var t = await _expenseBA.SaveAsync(DataItem);
//                }
//            }
//        }
//    }
//}
