using MyAccountModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccountModels
{
    [NotifyPropertyChanged]
    public class BillExpense : ModelBase
    {
        public BillExpense()
        {
            PaymentDateDue = DateTime.Now; 
        }
        private int _paymentDueDay;
        private DateTime _paymentDueDate; 
        public int ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public decimal Payment { get; set; }
        public string Notes { get; set;  }

        public bool HasBalance { get; set; }

        public decimal Balance { get; set; }

        public int PaymentDayDue
        {
            set {
                _paymentDueDay = PaymentDateDue.Day;
                OnPropertyChanged("PaymentDayDue");
            }
            get
            {
              
                return _paymentDueDay; 
            }
        }

        public DateTime PaymentDateDue
        {
            get { return _paymentDueDate;  }
            set
            {
                _paymentDueDate = value;
                PaymentDayDue = _paymentDueDate.Day;
                OnPropertyChanged("PayDateDue");
            }
        }
             

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
