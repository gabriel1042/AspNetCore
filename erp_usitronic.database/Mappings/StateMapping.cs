using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class StateMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("name")
                .HasDefaultValueSql("''");

            builder.Property(s => s.Initial)
                .IsRequired()
                .HasColumnType("VARCHAR(2)")
                .HasColumnName("initial")
                .HasDefaultValueSql("''");

            // 1 : N => State : Cities
            builder.HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .HasForeignKey(p => p.StateId);

            builder.ToTable("states");
        }
    }
}
