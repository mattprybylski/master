using MPAccountApplication.BaseWindow;
using MPAccountApplication.View;
using MyAccountModels;
using MyAccountsBusiness.BA;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MPAccountApplication.ViewModel
{
    public class BillExpenseViewModel : AbstractViewEditorModelWindow<BillExpenseViewWindow2, BillExpense>
    {
        private readonly BillExpenseBA _billExpenseBA;
     

        //public BilllExpenseType ExpenseType
        //{
        //    get { return (BilllExpenseType)this.GetValue(ExpenseTypeProperty); }
        //    set
        //    {
        //        this.SetValue(ExpenseTypeProperty, value);
        //        this.DataItem.ExpenseType = ExpenseType;
        //    }
        //}

        public string TotalBillExpense
        {
            get { return (string)this.GetValue(TotalBillExpenseProperty); }
            set
            {
                this.SetValue(TotalBillExpenseProperty, value);
            }
        }

        public bool HasBalance
        {
            get { return (bool)GetValue(IsCheckBoxCheckedProperty); }
            set { SetValue(IsCheckBoxCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
          DependencyProperty.Register("HasBalance", typeof(bool),
          typeof(BillExpenseViewModel), new UIPropertyMetadata(false));

        public static readonly DependencyProperty TotalBillExpenseProperty = DependencyProperty.Register(
          "TotalBillExpense", typeof(string), typeof(BillExpenseViewModel), new PropertyMetadata(string.Empty));
 
        //public static readonly DependencyProperty ExpenseTypeProperty = DependencyProperty.Register(
        //  "ExpenseType", typeof(BilllExpenseType), typeof(BillExpenseViewModel), new PropertyMetadata(null));


        //public ObservableCollection<BilllExpenseType> ExpenseTypes
        //{
        //    get { return _expenseTypes; }
        //    set
        //    {
        //        _expenseTypes = value;
        //        OnPropertyChanged("ExpenseTypes");
        //    }
        //}

        public BillExpenseViewModel()
        {
            _billExpenseBA = new BillExpenseBA();
      
            //ExpenseTypes = new ObservableCollection<BilllExpenseType>(); 
        }

        public async override Task ShowWindowAsync()
        {
            this.Window.DataContext = this; 
            this.Window.Show();

            //var items = await _expenseTypeBA.GetAsync();
            //items.ForEach(x => ExpenseTypes.Add(x));

            var bills = await _billExpenseBA.GetAsync();
            bills.ForEach(x => Items.Add(x));

            CalculateBillExpenses();

        }

        private void CalculateBillExpenses()
        {
            var totalExpenses = Items.Sum(x => x.Payment);
            TotalBillExpense = " Total Bill Expense = " + totalExpenses.ToString();
        }

        protected override void Bindable()
         {
            if (DataItem != null && DataItem.Id > 0)
            {
                //ExpenseType = ExpenseTypes.FirstOrDefault(x => x.Id == DataItem.ExpenseTypeId);
                HasBalance = DataItem.HasBalance; 
            }

        }

        protected async override Task Close_Command_Click_Async()
        {
            this.Window.Close(); 
        }

        protected async override Task Delete_Command_Click_Async()
        {
            var item = await _billExpenseBA.GetByIdAsync(DataItem.Id);
            if (item.Id > 0)
            {
                _billExpenseBA.Delete(item);
                Items.Remove(DataItem);

                CalculateBillExpenses();
            }
        }

        protected async override Task New_Command_Click_Async()
        {
            DataItem = null;
            DataItem = new BillExpense();
        }

        protected async override Task Save_Command_Click_Async()
        {
            //if(this.ExpenseType == null)
            //{
            //    MessageBox.Show("must pick an expense type");
            //    return; 
            //}

            //DataItem.ExpenseType = ExpenseType;
            //DataItem.ExpenseTypeId = ExpenseType.Id; 

            //if (DataItem.ExpenseType == null || DataItem.ExpenseType.Id == 0)
            //{
            //    DataItem.ExpenseType = ExpenseType;
            //}
            DataItem.HasBalance = HasBalance; 
            if (DataItem != null)
            {
                if (DataItem.Id == 0)
                {
                    var t = await _billExpenseBA.SaveAsync(DataItem);
                    Items.Add(t);
                }
                else
                {
                    var t = await _billExpenseBA.SaveAsync(DataItem);
                }
            }


            CalculateBillExpenses();
        }
    }
}
