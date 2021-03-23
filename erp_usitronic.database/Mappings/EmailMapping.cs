using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("description")
                .HasDefaultValueSql("''");

            builder.Property("PersonId")
                .HasColumnName("person_id");

            builder.ToTable("emails");
        }
    }
}
