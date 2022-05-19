using MyAccountModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDataField.DataField;

namespace MyAccountModels
{
    public class Account : ModelBase
    {
        public string BankName
        {
            get;set;
        }
        public string BankLocation
        {
            get; set;
        }
        public string Notes
        {
            get; set;
        }
        public string AccountNumber
        {
            get; set;
        }
        public string RoutingNumber
        {
            get; set;
        }
        public decimal Balance
        {
            get;set;
        }

        public override string ToString()
        {
            return BankName + " " + BankLocation; 
        }

        public bool PrimaryAccount { get; set; }
    }
}