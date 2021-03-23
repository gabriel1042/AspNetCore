using System;
using System.Collections.Generic;
using System.Text;
using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace erp_usitronic.database.Mappings
{
    public class PermissionMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(e => e.Resource)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("resource")
                .HasDefaultValueSql("''");

            builder.Property(e => e.Method)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("method")
                .HasDefaultValueSql("''");

            builder.Property(e => e.Authorized)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("authorized")
                .HasDefaultValueSql("0");

            builder.Property("ApiUserId")
                .HasColumnName("api_user_id");

            builder.ToTable("permissions");
        }
    }
}
