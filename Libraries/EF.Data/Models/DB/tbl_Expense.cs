﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EF.Data.Models.DB
{
    public partial class tbl_Expense
    {
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal AmountDue { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        public string DayDueText { get; set; }
        public string Notes { get; set; }
        public decimal? Balance { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual tbl_ExpenseType ExpenseType { get; set; }
    }
}