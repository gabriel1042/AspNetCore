using System;
using System.Collections.Generic;
using System.Text;
using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace erp_usitronic.database.Mappings
{
    public class FinancialMovementMapping : IEntityTypeConfiguration<FinancialMovement>
    {
        public void Configure(EntityTypeBuilder<FinancialMovement> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(c => c.TransactionDate)
                .IsRequired(false)
                .HasColumnType("DATETIME")
                .HasColumnName("transaction_date")
                .HasDefaultValueSql("null");

            builder.Property(c => c.PreviousBalance)
                .IsRequired()
                .HasColumnType("Decimal(9,2)")
                .HasColumnName("previous_balance")
                .HasDefaultValueSql("0");

            builder.Property(c => c.TransactionValue)
                .IsRequired()
                .HasColumnType("Decimal(9,2)")
                .HasColumnName("transaction_value")
                .HasDefaultValueSql("0");

            builder.Property(c => c.AfterBalance)
                .IsRequired()
                .HasColumnType("Decimal(9,2)")
                .HasColumnName("after_balance")
                .HasDefaultValueSql("0");

            builder.Property(c => c.Kind)
                .IsRequired()
                .HasColumnType("VARCHAR(1)")
                .HasColumnName("kind")
                .HasDefaultValueSql("''");

            // 1 : 1 => FinancialMovement : Bank
            builder.HasOne(c => c.Bank)
                .WithOne(p => p.FinancialMovement);

            builder.Property("BankId")
                .HasColumnName("bank_id");

            builder.ToTable("financial_movement");
        }
    }
}
