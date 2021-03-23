using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(s => s.CompanyName)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("company_name")
                .HasDefaultValueSql("''");

            builder.Property(s => s.StateRegistration)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("state_registration")
                .HasDefaultValueSql("''");

            // 1 : 1 => Supplier : Person
            builder.HasOne(s => s.Person)
                    .WithOne(p => p.Supplier);

            builder.Property("PersonId")
                .HasColumnName("person_id");

            builder.ToTable("suppliers");

        }
    }
}