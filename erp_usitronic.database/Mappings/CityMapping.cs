using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("name")
                .HasDefaultValueSql("''");

            builder.Property("StateId")
                .HasColumnName("state_id");

            builder.ToTable("cities");
        }
    }
}
