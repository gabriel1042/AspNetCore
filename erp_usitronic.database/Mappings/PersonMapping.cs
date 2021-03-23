using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property("Id")
                .HasColumnName("id");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("name")
                .HasDefaultValueSql("''");

            builder.Property(p => p.IdNumber)
                .IsRequired()
                .HasColumnType("VARCHAR(14)")
                .HasColumnName("id_number")
                .HasDefaultValueSql("''");

            builder.Property(p => p.KindPerson)
                .IsRequired()
                .HasColumnType("VARCHAR(1)")
                .HasColumnName("kind_person")
                .HasDefaultValueSql("''");

            builder.Ignore(p => p.FirstTelephone);
            builder.Ignore(p => p.FirstEmail);
            builder.Ignore(p => p.FirstAddress);

            // 1 : N => Person : Adresses
            builder.HasMany(p => p.Adresses)
                .WithOne(a => a.Person)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1 : N => Person : Emails
            builder.HasMany(p => p.Emails)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1 : N => Person : Telephones
            builder.HasMany(p => p.Telephones)
                .WithOne(t => t.Person)
                .HasForeignKey(t => t.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1 : N => Person : Customers
            builder.HasMany(p => p.Customers)
                .WithOne(t => t.Person)
                .HasForeignKey(t => t.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("people");
        }
    }
}
