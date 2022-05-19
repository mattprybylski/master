using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Model
{
    public class AccountLedger
    {
        public AccountLedger()
        {
            TransactionDescription = string.Empty; 
        }

        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int AccountId { get; set; }
        public decimal AccountNewBalance { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
    }
}
