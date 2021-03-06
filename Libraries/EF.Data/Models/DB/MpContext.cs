// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF.Data.Models.DB
{
    public partial class MpContext : DbContext
    {
        public MpContext()
        {
        }

        public MpContext(DbContextOptions<MpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbl_Account> tbl_Account { get; set; }
        public virtual DbSet<tbl_AccountLedger> tbl_AccountLedger { get; set; }
        public virtual DbSet<tbl_Expense> tbl_Expense { get; set; }
        public virtual DbSet<tbl_ExpenseBalance> tbl_ExpenseBalance { get; set; }
        public virtual DbSet<tbl_ExpenseType> tbl_ExpenseType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Account>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tbl_AccountLedger>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountNewBalance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.tbl_AccountLedger)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_tbl_AccountLedger_Account");
            });

            modelBuilder.Entity<tbl_Expense>(entity =>
            {
                entity.Property(e => e.AmountDue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateDue).HasColumnType("datetime");

                entity.Property(e => e.DayDueText)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.tbl_Expense)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .HasConstraintName("FK_tbl_Expense_ExpenseType");
            });

            modelBuilder.Entity<tbl_ExpenseBalance>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateLastPaid).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<tbl_ExpenseType>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}