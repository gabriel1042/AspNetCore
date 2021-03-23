using erp_usitronic.business.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erp_usitronic.Database
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetIndexes())) relationship.IsUnique = false;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ApiUser> ApiUsers { get; set; }
        public DbSet<FinancialMovement> FinancialMovements { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
