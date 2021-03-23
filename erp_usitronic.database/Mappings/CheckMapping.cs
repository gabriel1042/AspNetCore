using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class CheckMapping : IEntityTypeConfiguration<Check>
    {
        public void Configure(EntityTypeBuilder<Check> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(c => c.Issuer)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("issuer")
                .HasDefaultValueSql("''");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("number")
                .HasDefaultValueSql("0");

            // 1 : 1 => Check : Bank
            builder.HasOne(c => c.Bank)
                .WithOne(b => b.Check);

            builder.Property("BankId")
                .HasColumnName("bank_id");
            builder.Property("PaymentId")
               .HasColumnName("payment_id");

            builder.ToTable("checks");
        }
    }
}
