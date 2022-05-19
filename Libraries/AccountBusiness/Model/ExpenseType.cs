using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Model
{
    public class ExpenseType
    {

        public ExpenseType() { Name = string.Empty; }

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
