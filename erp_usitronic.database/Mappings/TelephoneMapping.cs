using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class TelephoneMapping : IEntityTypeConfiguration<Telephone>
    {
        public void Configure(EntityTypeBuilder<Telephone> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(t => t.Number)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("number")                
                .HasDefaultValueSql("''");

            builder.Property("PersonId")
                .HasColumnName("person_id");

            builder.ToTable("telephones");
        }
    }
}
