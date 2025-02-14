﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using erp_usitronic.Database;

namespace erp_usitronic.database.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20210317022657_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("erp_usitronic.business.models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnName("city_id")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("neighborhood")
                        .HasColumnType("VARCHAR(80)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Number")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("number")
                        .HasColumnType("VARCHAR(10)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("street_name")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("zip_code")
                        .HasColumnType("VARCHAR(8)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PersonId");

                    b.ToTable("adresses");
                });

            modelBuilder.Entity("erp_usitronic.business.models.ApiToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnName("access_token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created")
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("null");

                    b.Property<DateTime?>("Expiration")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("expiration")
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("null");

                    b.HasKey("Id");

                    b.ToTable("api_tokens");
                });

            modelBuilder.Entity("erp_usitronic.business.models.ApiUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessKey")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("access_key")
                        .HasColumnType("VARCHAR(32)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(20)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.ToTable("api_users");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("balance")
                        .HasColumnType("Decimal(9,2)")
                        .HasDefaultValueSql("0");

                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("code")
                        .HasColumnType("INT")
                        .HasDefaultValueSql("0");

                    b.Property<int>("EntersCashFlow")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("enters_cash_flow")
                        .HasColumnType("INT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.ToTable("banks");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Check", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankId")
                        .HasColumnName("bank_id")
                        .HasColumnType("int");

                    b.Property<string>("Issuer")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("issuer")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("number")
                        .HasColumnType("INT")
                        .HasDefaultValueSql("0");

                    b.Property<int>("PaymentId")
                        .HasColumnName("payment_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("PaymentId");

                    b.ToTable("checks");
                });

            modelBuilder.Entity("erp_usitronic.business.models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("StateId")
                        .HasColumnName("state_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CnpjNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cnpj_number")
                        .HasColumnType("VARCHAR(14)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("company_name")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("StateRegistration")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("state_registration")
                        .HasColumnType("VARCHAR(20)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("company_name")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("int");

                    b.Property<string>("StateRegistration")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("state_registration")
                        .HasColumnType("VARCHAR(20)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("description")
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("emails");
                });

            modelBuilder.Entity("erp_usitronic.business.models.FinancialMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AfterBalance")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("after_balance")
                        .HasColumnType("Decimal(9,2)")
                        .HasDefaultValueSql("0");

                    b.Property<int>("BankId")
                        .HasColumnName("bank_id")
                        .HasColumnType("int");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("kind")
                        .HasColumnType("VARCHAR(1)")
                        .HasDefaultValueSql("''");

                    b.Property<decimal>("PreviousBalance")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("previous_balance")
                        .HasColumnType("Decimal(9,2)")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("TransactionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("transaction_date")
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("null");

                    b.Property<decimal>("TransactionValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("transaction_value")
                        .HasColumnType("Decimal(9,2)")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("financial_movement");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankId")
                        .HasColumnName("bank_id")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnName("company_id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("description")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("KindPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("kind_payment")
                        .HasColumnType("VARCHAR(20)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("Paid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("paid")
                        .HasColumnType("INT")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("payment_date")
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("null");

                    b.Property<decimal>("PaymentValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("payment_value")
                        .HasColumnType("Decimal(9,2)")
                        .HasDefaultValueSql("0");

                    b.Property<int>("SupplierId")
                        .HasColumnName("supplier_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SupplierId");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApiUserId")
                        .HasColumnName("api_user_id")
                        .HasColumnType("int");

                    b.Property<int>("Authorized")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("authorized")
                        .HasColumnType("INT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Method")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("method")
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Resource")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("resource")
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.HasIndex("ApiUserId");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_number")
                        .HasColumnType("VARCHAR(14)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("KindPerson")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("kind_person")
                        .HasColumnType("VARCHAR(1)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.ToTable("people");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankId")
                        .HasColumnName("bank_id")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnName("company_id")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("description")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.Property<int?>("InvoiceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("invoice_number")
                        .HasColumnType("INT")
                        .HasDefaultValueSql("null");

                    b.Property<int>("Paid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("paid")
                        .HasColumnType("INT")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("ReceiptDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("receipt_date")
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("null");

                    b.Property<decimal>("ReceiptValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("receipt_value")
                        .HasColumnType("Decimal(9,2)")
                        .HasDefaultValueSql("0");

                    b.Property<string>("ShippingSituation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("shipping_situation")
                        .HasColumnType("VARCHAR(10)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("receipts");
                });

            modelBuilder.Entity("erp_usitronic.business.models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Initial")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("initial")
                        .HasColumnType("VARCHAR(2)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.ToTable("states");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("company_name")
                        .HasColumnType("VARCHAR(255)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("int");

                    b.Property<string>("StateRegistration")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("state_registration")
                        .HasColumnType("VARCHAR(20)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("number")
                        .HasColumnType("VARCHAR(20)")
                        .HasDefaultValueSql("''");

                    b.Property<int>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("telephones");
                });

            modelBuilder.Entity("erp_usitronic.business.models.Address", b =>
                {
                    b.HasOne("erp_usitronic.business.models.City", "City")
                        .WithOne("Address")
                        .HasForeignKey("erp_usitronic.business.models.Address", "CityId")
                        .IsRequired();

                    b.HasOne("erp_usitronic.business.models.Person", "Person")
                        .WithMany("Adresses")
                        .HasForeignKey("PersonId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Check", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Bank", "Bank")
                        .WithOne("Check")
                        .HasForeignKey("erp_usitronic.business.models.Check", "BankId")
                        .IsRequired();

                    b.HasOne("erp_usitronic.business.models.Payment", "Payment")
                        .WithOne("Check")
                        .HasForeignKey("erp_usitronic.business.models.Check", "PaymentId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.City", b =>
                {
                    b.HasOne("erp_usitronic.business.models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Customer", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Person", "Person")
                        .WithMany("Customers")
                        .HasForeignKey("PersonId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Email", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Person", "Person")
                        .WithMany("Emails")
                        .HasForeignKey("PersonId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.FinancialMovement", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Bank", "Bank")
                        .WithOne("FinancialMovement")
                        .HasForeignKey("erp_usitronic.business.models.FinancialMovement", "BankId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Payment", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Bank", "Bank")
                        .WithOne("Payment")
                        .HasForeignKey("erp_usitronic.business.models.Payment", "BankId")
                        .IsRequired();

                    b.HasOne("erp_usitronic.business.models.Company", "Company")
                        .WithOne("Payment")
                        .HasForeignKey("erp_usitronic.business.models.Payment", "CompanyId")
                        .IsRequired();

                    b.HasOne("erp_usitronic.business.models.Supplier", "Supplier")
                        .WithOne("Payment")
                        .HasForeignKey("erp_usitronic.business.models.Payment", "SupplierId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Permission", b =>
                {
                    b.HasOne("erp_usitronic.business.models.ApiUser", "ApiUser")
                        .WithMany("Permissions")
                        .HasForeignKey("ApiUserId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Receipt", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Bank", "Bank")
                        .WithOne("Receipt")
                        .HasForeignKey("erp_usitronic.business.models.Receipt", "BankId")
                        .IsRequired();

                    b.HasOne("erp_usitronic.business.models.Company", "Company")
                        .WithOne("Receipt")
                        .HasForeignKey("erp_usitronic.business.models.Receipt", "CompanyId")
                        .IsRequired();

                    b.HasOne("erp_usitronic.business.models.Customer", "Customer")
                        .WithOne("Receipt")
                        .HasForeignKey("erp_usitronic.business.models.Receipt", "CustomerId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Supplier", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Person", "Person")
                        .WithOne("Supplier")
                        .HasForeignKey("erp_usitronic.business.models.Supplier", "PersonId")
                        .IsRequired();
                });

            modelBuilder.Entity("erp_usitronic.business.models.Telephone", b =>
                {
                    b.HasOne("erp_usitronic.business.models.Person", "Person")
                        .WithMany("Telephones")
                        .HasForeignKey("PersonId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
