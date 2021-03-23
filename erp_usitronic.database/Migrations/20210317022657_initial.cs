using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace erp_usitronic.database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "api_tokens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "null"),
                    expiration = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "null"),
                    access_token = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_tokens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "api_users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "''"),
                    access_key = table.Column<string>(type: "VARCHAR(32)", nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValueSql: "''"),
                    code = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "0"),
                    balance = table.Column<decimal>(type: "Decimal(9,2)", nullable: false, defaultValueSql: "0"),
                    enters_cash_flow = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    cnpj_number = table.Column<string>(type: "VARCHAR(14)", nullable: false, defaultValueSql: "''"),
                    state_registration = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    kind_person = table.Column<string>(type: "VARCHAR(1)", nullable: false, defaultValueSql: "''"),
                    id_number = table.Column<string>(type: "VARCHAR(14)", nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValueSql: "''"),
                    initial = table.Column<string>(type: "VARCHAR(2)", nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resource = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValueSql: "''"),
                    method = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValueSql: "''"),
                    authorized = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "0"),
                    api_user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_permissions_api_users_api_user_id",
                        column: x => x.api_user_id,
                        principalTable: "api_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "financial_movement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_date = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "null"),
                    previous_balance = table.Column<decimal>(type: "Decimal(9,2)", nullable: false, defaultValueSql: "0"),
                    transaction_value = table.Column<decimal>(type: "Decimal(9,2)", nullable: false, defaultValueSql: "0"),
                    after_balance = table.Column<decimal>(type: "Decimal(9,2)", nullable: false, defaultValueSql: "0"),
                    kind = table.Column<string>(type: "VARCHAR(1)", nullable: false, defaultValueSql: "''"),
                    bank_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_movement", x => x.id);
                    table.ForeignKey(
                        name: "FK_financial_movement_banks_bank_id",
                        column: x => x.bank_id,
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    state_registration = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "''"),
                    person_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_customers_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "emails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValueSql: "''"),
                    person_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emails", x => x.id);
                    table.ForeignKey(
                        name: "FK_emails_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    state_registration = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "''"),
                    person_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "telephones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "''"),
                    person_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telephones", x => x.id);
                    table.ForeignKey(
                        name: "FK_telephones_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValueSql: "''"),
                    state_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_states_state_id",
                        column: x => x.state_id,
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receipt_date = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "null"),
                    receipt_value = table.Column<decimal>(type: "Decimal(9,2)", nullable: false, defaultValueSql: "0"),
                    invoice_number = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "null"),
                    shipping_situation = table.Column<string>(type: "VARCHAR(10)", nullable: true, defaultValueSql: "''"),
                    description = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    paid = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "0"),
                    company_id = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    bank_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.id);
                    table.ForeignKey(
                        name: "FK_receipts_banks_bank_id",
                        column: x => x.bank_id,
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_receipts_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_receipts_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_date = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "null"),
                    payment_value = table.Column<decimal>(type: "Decimal(9,2)", nullable: false, defaultValueSql: "0"),
                    kind_payment = table.Column<string>(type: "VARCHAR(20)", nullable: true, defaultValueSql: "''"),
                    description = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    paid = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "0"),
                    company_id = table.Column<int>(nullable: false),
                    supplier_id = table.Column<int>(nullable: false),
                    bank_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_payments_banks_bank_id",
                        column: x => x.bank_id,
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payments_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payments_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street_name = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    number = table.Column<string>(type: "VARCHAR(10)", nullable: false, defaultValueSql: "''"),
                    neighborhood = table.Column<string>(type: "VARCHAR(80)", nullable: false, defaultValueSql: "''"),
                    zip_code = table.Column<string>(type: "VARCHAR(8)", nullable: false, defaultValueSql: "''"),
                    person_id = table.Column<int>(nullable: false),
                    city_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_adresses_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adresses_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "checks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuer = table.Column<string>(type: "VARCHAR(255)", nullable: false, defaultValueSql: "''"),
                    number = table.Column<int>(type: "INT", nullable: false, defaultValueSql: "0"),
                    bank_id = table.Column<int>(nullable: false),
                    payment_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checks", x => x.id);
                    table.ForeignKey(
                        name: "FK_checks_banks_bank_id",
                        column: x => x.bank_id,
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_checks_payments_payment_id",
                        column: x => x.payment_id,
                        principalTable: "payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresses_city_id",
                table: "adresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_adresses_person_id",
                table: "adresses",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_checks_bank_id",
                table: "checks",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_checks_payment_id",
                table: "checks",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_state_id",
                table: "cities",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_person_id",
                table: "customers",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_emails_person_id",
                table: "emails",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_financial_movement_bank_id",
                table: "financial_movement",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_bank_id",
                table: "payments",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_company_id",
                table: "payments",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_supplier_id",
                table: "payments",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_api_user_id",
                table: "permissions",
                column: "api_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_bank_id",
                table: "receipts",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_company_id",
                table: "receipts",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_customer_id",
                table: "receipts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_person_id",
                table: "suppliers",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_telephones_person_id",
                table: "telephones",
                column: "person_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adresses");

            migrationBuilder.DropTable(
                name: "api_tokens");

            migrationBuilder.DropTable(
                name: "checks");

            migrationBuilder.DropTable(
                name: "emails");

            migrationBuilder.DropTable(
                name: "financial_movement");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "telephones");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "api_users");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
