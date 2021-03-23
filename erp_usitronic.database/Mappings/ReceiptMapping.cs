using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class ReceiptMapping : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(r => r.ReceiptDate)
                .IsRequired(false)
                .HasColumnType("DATE")
                .HasColumnName("receipt_date")
                .HasDefaultValueSql("null");

            builder.Property(r => r.ReceiptValue)
                .IsRequired()
                .HasColumnType("Decimal(9,2)")
                .HasColumnName("receipt_value")
                .HasDefaultValueSql("0");

            builder.Property(r => r.InvoiceNumber)
                .IsRequired(false)
                .HasColumnType("INT")
                .HasColumnName("invoice_number")
                .HasDefaultValueSql("null");

            builder.Property(r => r.ShippingSituation)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("shipping_situation")
                .HasDefaultValueSql("''");

            builder.Property(r => r.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("description")
                .HasDefaultValueSql("''");

            builder.Property(r => r.Paid)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("paid")
                .HasDefaultValueSql("0");

            // 1 : 1 => Receipt : Customer
            builder.HasOne(r => r.Customer)
                .WithOne(c => c.Receipt);

            // 1 : 1 => Receipt : Company
            builder.HasOne(r => r.Company)
                .WithOne(c => c.Receipt);

            // 1 : 1 => Receipt : Bank
            builder.HasOne(r => r.Bank)
                .WithOne(c => c.Receipt);

            builder.Property("CompanyId")
                .HasColumnName("company_id");

            builder.Property("CustomerId")
                .HasColumnName("customer_id");

            builder.Property("BankId")
                .HasColumnName("bank_id");

            builder.ToTable("receipts");
        }
    }
}
