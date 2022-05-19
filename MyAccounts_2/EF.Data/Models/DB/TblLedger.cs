﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace EF.Data.Models.DB
{
    public partial class TblLedger
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BillExpenseId { get; set; }
        public string TransactionType { get; set; }
        public decimal Payment { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Balance { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual TblAccount Account { get; set; }
        public virtual TblBillExpense BillExpense { get; set; }
    }
}