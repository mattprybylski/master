using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccountModels
{

    public class Legder : ModelBase 
    {
        private decimal _payment; 
        public Legder()
        {
            Account = new Account();
            PaymentDate = DateTime.Now; 
        }
        public BillExpense BillExpense { get; set; }
        public int BillExpenseId { get; set; }
        public string TransactionType { get; set; }
        public decimal Payment
        {
            get { return _payment; }
            set
            {
                _payment = value;
                OnPropertyChanged("Payment");
            }
        }
            
        public DateTime PaymentDate { get; set; }
        public decimal Balance { get; set;  }
        public string Notes { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }

        public string PaymentString
        {
            get
            {
                if (!string.IsNullOrEmpty(TransactionType))
                {
                    if(TransactionType.ToLower().Trim() == "credit")
                    {
                        return "+ $" + Payment.ToString(); 
                    }
                    else
                    {
                        return "($" + Payment.ToString() + ")"; 
                    }
                }
                else
                {
                    return string.Empty; 
                }
            }
        }
    }
}
