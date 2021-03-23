using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(p => p.PaymentDate)
                .IsRequired(false)
                .HasColumnType("DATE")
                .HasColumnName("payment_date")
                .HasDefaultValueSql("null");

            builder.Property(p => p.PaymentValue)
                .IsRequired()
                .HasColumnType("Decimal(9,2)")
                .HasColumnName("payment_value")
                .HasDefaultValueSql("0");

            builder.Property(p => p.KindPayment)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("kind_payment")
                .HasDefaultValueSql("''");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("description")
                .HasDefaultValueSql("''");

            builder.Property(p => p.Paid)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("paid")
                .HasDefaultValueSql("0");

            // 1 : 1 => Payment : Supplier
            builder.HasOne(p => p.Supplier)
                .WithOne(c => c.Payment);

            // 1 : 1 => Payment : Company
            builder.HasOne(p => p.Company)
                .WithOne(c => c.Payment);

            // 1 : 1 => Payment : Company
            builder.HasOne(p => p.Check)
                .WithOne(c => c.Payment);

            builder.HasOne(p => p.Bank)
                .WithOne(c => c.Payment);

            builder.Property("CompanyId")
                .HasColumnName("company_id");           

            builder.Property("SupplierId")
                .HasColumnName("supplier_id");

            builder.Property("BankId")
                .HasColumnName("bank_id");

            builder.ToTable("payments");
        }
    }
}
