//using MyAccountModels.Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyAccountModels
//{
//    public class Expense : ModelBase
//    {
//        private BilllExpenseType _expenseType;
//       public int ExpenseTypeId { get; set; }
 
       
//        public BilllExpenseType ExpenseType
//        {
//            get { return _expenseType;  }
//            set
//            {
//                OnPropertyChanged("ExpenseType");
//                _expenseType = value ;
//            }
//        }
             

//        public string Name { get; set; }
//        public string Notes { get; set; }
//        public decimal Balance { get; set; }
//        public decimal Payment { get; set; }
//        public ExpenseDuration ExpenseDuration { get; set; }
//    }
//}
