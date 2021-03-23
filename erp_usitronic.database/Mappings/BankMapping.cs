using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class BankMapping : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("name")
                .HasDefaultValueSql("''");

            builder.Property(b => b.Code)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("code")
                .HasDefaultValueSql("0");

            builder.Property(b => b.Balance)
                .IsRequired()
                .HasColumnType("Decimal(9,2)")
                .HasColumnName("balance")
                .HasDefaultValueSql("0");

            builder.Property(b => b.EntersCashFlow)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("enters_cash_flow")
                .HasDefaultValueSql("0");

            builder.ToTable("banks");
        }
    }
}
