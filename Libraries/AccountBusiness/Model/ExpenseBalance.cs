using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Model
{
    public class ExpenseBalance
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public decimal Balance { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DateLastPaid { get; set; }
        public DateTime NextDueDate { get; set; }
    }
}
