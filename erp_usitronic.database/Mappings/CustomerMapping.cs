using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("company_name")
                .HasDefaultValueSql("''");

            builder.Property(c => c.StateRegistration)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("state_registration")
                .HasDefaultValueSql("''");

            //// 1 : 1 => Customer : Person
            //builder.HasOne(s => s.Person)
            //        .WithOne(p => p.Customer)
            //        .OnDelete(DeleteBehavior.Cascade);

            builder.Property("PersonId")
                .HasColumnName("person_id");

            builder.ToTable("customers");
        }
    }
}
