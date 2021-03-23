using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class ApiTokenMapping : IEntityTypeConfiguration<ApiToken>
    {
        public void Configure(EntityTypeBuilder<ApiToken> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(a => a.Created)
                .IsRequired(false)
                .HasColumnType("DATETIME")
                .HasColumnName("created")
                .HasDefaultValueSql("null");

            builder.Property(a => a.Expiration)
                .IsRequired(false)
                .HasColumnType("DATETIME")
                .HasColumnName("expiration")
                .HasDefaultValueSql("null");

            builder.Property(a => a.AccessToken)
                .IsRequired()
                .HasColumnName("access_token");

            builder.ToTable("api_tokens");
        }
    }
}
