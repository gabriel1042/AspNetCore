using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class ApiUserMapping : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("name")
                .HasDefaultValueSql("''");

            builder.Property(a => a.AccessKey)
                .IsRequired()
                .HasColumnType("VARCHAR(32)")
                .HasColumnName("access_key")
                .HasDefaultValueSql("''");

            // 1 : N => User : Permissions
            builder.HasMany(s => s.Permissions)
                .WithOne(c => c.ApiUser)
                .HasForeignKey(p => p.ApiUserId);

            builder.ToTable("api_users");
        }
    }
}
