using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Model
{
    public class Expense : ModelBase
    {
        private DateTime _dateDue;
        private string _dayDueText;
        private string _name; 
        private ExpenseType _expenseType;
        private decimal _balance;
        private decimal _amountDue;

        public Expense()
        {
            Name            = string.Empty;
            Description     = string.Empty;
            Notes           = string.Empty;
            DayDueText      = string.Empty;
            DateDue         = DateTime.Now;
            ExpenseType = new ExpenseType(); 
        }

   
        public int ExpenseTypeId
        {
            get { return  ExpenseType != null ? ExpenseType.Id : 0 ; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description { get; set; }
        public DateTime DateDue
        {
            get { return _dateDue; }
            set
            {
                _dateDue = value; 
                OnPropertyChanged("DateDue");
                DayDueText = "Due on the " + _dateDue.Day.ToString() + " of every month."; 
            }
        }
        public string DayDueText
        {
            get { return _dayDueText; }
            set
            {
                _dayDueText = value;
                OnPropertyChanged("DayDueText"); 
            }
        }
        public string Notes { get; set; }
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPropertyChanged("Balance"); 
            }
        }
        public decimal AmountDue
        {
            get { return _amountDue; }
            set
            {
                _amountDue = value;
                OnPropertyChanged("AmountDue");
            }
        }
        public ExpenseType ExpenseType
        {
            get { return _expenseType; }
            set
            {
                _expenseType = value;
                OnPropertyChanged("ExpenseType");
            }
        }

        public bool HasBalance
        {
            get { return Balance > 0; }
        }
    }
}
