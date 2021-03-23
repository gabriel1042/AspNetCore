using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("company_name")
                .HasDefaultValueSql("''");

            builder.Property(c => c.CnpjNumber)
                .IsRequired()
                .HasColumnType("VARCHAR(14)")
                .HasColumnName("cnpj_number")
                .HasDefaultValueSql("''");

            builder.Property(c => c.StateRegistration)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("state_registration")
                .HasDefaultValueSql("''");

            builder.ToTable("companies");
        }
    }
}
