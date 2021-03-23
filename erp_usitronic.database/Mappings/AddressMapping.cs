using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(s => s.StreetName)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("street_name")
                .HasDefaultValueSql("''");

            builder.Property(s => s.Neighborhood)
                .IsRequired()
                .HasColumnType("VARCHAR(80)")
                .HasColumnName("neighborhood")
                .HasDefaultValueSql("''");

            builder.Property(s => s.Number)
                .IsRequired()
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("number")
                .HasDefaultValueSql("''");

            builder.Property(s => s.ZipCode)
                .IsRequired()
                .HasColumnType("VARCHAR(8)")
                .HasColumnName("zip_code")
                .HasDefaultValueSql("''");

            // 1 : 1 => Address : City            
            builder.HasOne(a => a.City)
                .WithOne(c => c.Address);
            builder.Property("CityId")
                .HasColumnName("city_id");
            builder.Property("PersonId")
                .HasColumnName("person_id");

            builder.ToTable("adresses");
        }
    }
}
