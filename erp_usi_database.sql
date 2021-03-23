-- --------------------------------------------------------
-- Host:                         \\.\pipe\MSSQL$SQLEXPRESS\sql\query
-- Server version:               Microsoft SQL Server 2019 (RTM) - 15.0.2000.5
-- Server OS:                    Windows 10 Pro 10.0 <X64> (Build 18363: ) (Hypervisor)
-- HeidiSQL Version:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping data for table erp_usi.adresses: 0 rows
/*!40000 ALTER TABLE "adresses" DISABLE KEYS */;
/*!40000 ALTER TABLE "adresses" ENABLE KEYS */;

-- Dumping data for table erp_usi.api_tokens: 3 rows
/*!40000 ALTER TABLE "api_tokens" DISABLE KEYS */;
SET IDENTITY_INSERT api_tokens ON;
INSERT INTO "api_tokens" ("id", "created", "expiration", "access_token") VALUES
	(1, '2021-01-27 23:10:58.843', '2021-01-28 11:10:58.843', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJlcnBfdXNpdHJvbmljIiwiZXJwX3VzaXRyb25pYyJdLCJqdGkiOiIyNGM0YzMzOTA3N2Q0N2YzYjkyNTg2ODMyYWIyYzY1YSIsIm5iZiI6MTYxMTc5OTg1OCwiZXhwIjoxNjExODQzMDU4LCJpYXQiOjE2MTE3OTk4NTgsImlzcyI6ImVycF91c2l0cm9uaWMuYXBpIiwiYXVkIjoiZXJwX3VzaXRyb25pYyJ9.n5-9FtxfV6X4exUOSjwognZTZmHVxOMpY8YW1Ns5HSwd8XsQfVzG3cMoJzC4MriZBuDJxQhwrysAoWGD2sWftE2af3k0mFh6spXlKpejsZjdTaVUiAJWmX4DAFpxQbJfxlNdbNorH_XPej5BmPSDOMSSk4Ply70wAx2t1xASbfBJPJHR5nHEVuEaYB6acxJmAGz3HO7YepNS23bfmwWCvffT06J8cUDCOimrECug0cqGwoFQYy8tpKNwASf6qAA1H1eFytA5LuKSxEGnqiegoN4pW_K0DlwwuntczdDrPcNVVI-QO6NU5KQ2WAR4Y1s3JOdb9NUXw49s6fC36UF5Wg'),
	(2, '2021-02-04 01:51:02.607', '2021-02-04 13:51:02.607', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJlcnBfdXNpdHJvbmljIiwiZXJwX3VzaXRyb25pYyJdLCJqdGkiOiJkZWMwYjQ5M2ZmOGQ0YTkyODhiZjBjODZiNTVhNmRjYSIsIm5iZiI6MTYxMjQxNDI2MiwiZXhwIjoxNjEyNDU3NDYyLCJpYXQiOjE2MTI0MTQyNjIsImlzcyI6ImVycF91c2l0cm9uaWMuYXBpIiwiYXVkIjoiZXJwX3VzaXRyb25pYyJ9.TLmAzueXUanw0wjkBJufXfE_-YcffMNyL1DId1a7j08CV41_OtHw84m28lqNu84HSyFLQnfbESvHAZ_fhD97pPgLOPilYwk2tsSnY_USFl5Q3t6Vvbq8mUwDg6RxcLNm-695IMVmOoRVp54q9u2S0KJuf43Rg53OzNsgtfmIELmIwHhY56CwPRyP7g1otQ2t24NfmYxtt9PY-3m9drcoaUnD85dW5rcmcMeEwqVFfBNHA3t_2mjlRwrW0drq9ls7CXk9iUAgf3VoST00JvqBPMGYoXDYwLqpG2XuZTqDzHdja666Ht3QXRroABqJLgutjvA5GpkNmu8NzI-G7UqTFQ'),
	(3, '2021-02-04 01:51:05.560', '2021-02-04 13:51:05.560', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJlcnBfdXNpdHJvbmljIiwiZXJwX3VzaXRyb25pYyJdLCJqdGkiOiI2N2FjYjNlOTE5ZTM0NTVjYWE0ZWYxOTc4MWE0NmMxYSIsIm5iZiI6MTYxMjQxNDI2NSwiZXhwIjoxNjEyNDU3NDY1LCJpYXQiOjE2MTI0MTQyNjUsImlzcyI6ImVycF91c2l0cm9uaWMuYXBpIiwiYXVkIjoiZXJwX3VzaXRyb25pYyJ9.MDKJW2wq9YwGsnPA2bFWQRnJ24YjexvNUoi4kX0-gQ-EDkmoKwSoGiXN2Qxl_TegkJZ3e90qLlCnH3_285lWuLiB_enLqcQ88mZoA6nwfj1QqfngRoYc44C4r9cyj7qyznx7ls9MIkS_4G7oM1JOGYjoJKZGsVif_qlR2DyjEpQlTZ3uMMN_q8U0h8-E1ZnKQ3JqfKH-yXInP9WaYXzFB2iN0YiMxXZouliTmZsur4quIhRxVGhgS70M8axDoGQ5EvKmK_7sIRF7854LAj6u27CV1HTvKeF7hh82riCKXV1tT7NeH8bP1hJGvLjfDd9wAS5bef5ylrRJrK7mme9aTw');
SET IDENTITY_INSERT api_tokens OFF;
/*!40000 ALTER TABLE "api_tokens" ENABLE KEYS */;

-- Dumping data for table erp_usi.api_users: 1 rows
/*!40000 ALTER TABLE "api_users" DISABLE KEYS */;
SET IDENTITY_INSERT api_users ON
INSERT INTO "api_users" ("id", "name", "access_key") VALUES
	(1, 'usitronic', 'usi010203');
SET IDENTITY_INSERT api_users OFF
/*!40000 ALTER TABLE "api_users" ENABLE KEYS */;

-- Dumping data for table erp_usi.banks: 1 rows
/*!40000 ALTER TABLE "banks" DISABLE KEYS */;
SET IDENTITY_INSERT banks ON;
INSERT INTO "banks" ("id", "name", "code", "balance", "enters_cash_flow") VALUES
	(1, 'Itaú', 341, 0, 0);
SET IDENTITY_INSERT banks off;
/*!40000 ALTER TABLE "banks" ENABLE KEYS */;

-- Dumping data for table erp_usi.checks: 1 rows
/*!40000 ALTER TABLE "checks" DISABLE KEYS */;
SET IDENTITY_INSERT checks ON;
INSERT INTO "checks" ("id", "issuer", "number", "bank_id", "payment_id") VALUES
	(1, 'Ustronic Peças', 101010, 1, 2);
SET IDENTITY_INSERT checks off;
/*!40000 ALTER TABLE "checks" ENABLE KEYS */;

-- Dumping data for table erp_usi.cities: 0 rows
/*!40000 ALTER TABLE "cities" DISABLE KEYS */;
/*!40000 ALTER TABLE "cities" ENABLE KEYS */;

-- Dumping data for table erp_usi.companies: 1 rows
/*!40000 ALTER TABLE "companies" DISABLE KEYS */;
SET IDENTITY_INSERT companies ON;
INSERT INTO "companies" ("id", "company_name", "cnpj_number", "state_registration") VALUES
	(1, 'Usitronic Peças e Equipamentos', '24614617000165', '0123012310');
SET IDENTITY_INSERT companies off;
/*!40000 ALTER TABLE "companies" ENABLE KEYS */;

-- Dumping data for table erp_usi.customers: 4 rows
/*!40000 ALTER TABLE "customers" DISABLE KEYS */;
SET IDENTITY_INSERT customers ON;
INSERT INTO "customers" ("id", "company_name", "state_registration", "person_id") VALUES
	(1, 'ClienteA', '000888', 1),
	(2, 'ClienteB', '000999', 2),
	(3, 'ClienteC', '000999', 3),
	(4, 'ClienteD', '000999', 2);

SET IDENTITY_INSERT customers off;
/*!40000 ALTER TABLE "customers" ENABLE KEYS */;

-- Dumping data for table erp_usi.emails: 0 rows
/*!40000 ALTER TABLE "emails" DISABLE KEYS */;
/*!40000 ALTER TABLE "emails" ENABLE KEYS */;

-- Dumping data for table erp_usi.payments: 7 rows
/*!40000 ALTER TABLE "payments" DISABLE KEYS */;
SET IDENTITY_INSERT payments ON;
INSERT INTO "payments" ("id", "payment_date", "payment_value", "kind_payment", "description", "paid", "company_id", "supplier_id", "bank_id") VALUES
	(1, '2021-02-02', 50, 'BOLETO', 'pagamento do aço xpto', 0, 1, 1,1),
	(2, '2021-02-02', 1500.33, 'CHEQUE', 'pagamento do tempera xpto', 0, 1, 2,1),
	(3, '2021-02-09', 300, 'BOLETO', 'pagamento xpto', 0, 1, 1,1),
	(4, '2021-02-09', 300, 'BOLETO', 'pagamento xpto', 0, 1, 2,1),
	(5, '2021-02-09', 300, 'BOLETO', 'pagamento xpto', 0, 1, 3,1),
	(6, '2021-02-20', 400, 'BOLETO', 'pagamento xpto', 0, 1, 3,1),
	(7, '2021-02-25', 1500, 'BOLETO', 'pagamento xpto', 0, 1, 3,1);
SET IDENTITY_INSERT payments off;
/*!40000 ALTER TABLE "payments" ENABLE KEYS */;

-- Dumping data for table erp_usi.people: 6 rows
/*!40000 ALTER TABLE "people" DISABLE KEYS */;
SET IDENTITY_INSERT people ON;
INSERT INTO "people" ("id", "name", "kind_person", "id_number") VALUES
	(1, 'Gabriel Pires', 'F','12213457611'),
	(2, 'Solum', 'J', '43281005000142'),
	(3, 'Rht', 'J', '61403567000101'),
	(4, 'Santa Rita', 'J', '13679838000103'),
	(5, 'Tempera', 'J', '34439118000132'),
	(6, 'Aco Tubo', 'J', '71069665000108');
SET IDENTITY_INSERT people off;
/*!40000 ALTER TABLE "people" ENABLE KEYS */;

-- Dumping data for table erp_usi.receipts: 7 rows
/*!40000 ALTER TABLE "receipts" DISABLE KEYS */;
SET IDENTITY_INSERT receipts on;
INSERT INTO "receipts" ("id", "receipt_date", "receipt_value", "invoice_number", "shipping_situation", "description", "paid", "company_id", "customer_id", "bank_id") VALUES
	(1, '2021-02-01', 100, NULL, 'ENVIADO', 'recebimento xpto', 0, 1, 1,1 ),
	(2, '2021-02-01', 120.33, NULL, 'ENVIADO', 'recebimento xpto', 0, 1, 2,1),
	(3, '2021-02-02', 2444.3, NULL, 'ENVIADO', 'recebimento xpto', 0, 1, 3,1),
	(4, '2021-02-05', 200, NULL, 'ENVIADO', 'recebimento xpto', 0, 1, 2,1),
	(5, '2021-02-06', 200, NULL, 'ENVIADO', 'recebimento xpto', 0, 1, 3,1),
	(6, '2021-02-06', 300, NULL, 'ENVIADO', 'recebimento xpto', 0, 1, 4,1),
	(7, '2021-02-20', 1000, NULL, 'ENVIADO', 'recebimento xpto', 0, 1, 1,1);
	SET IDENTITY_INSERT receipts off;
/*!40000 ALTER TABLE "receipts" ENABLE KEYS */;

-- Dumping data for table erp_usi.states: 0 rows
/*!40000 ALTER TABLE "states" DISABLE KEYS */;
/*!40000 ALTER TABLE "states" ENABLE KEYS */;

-- Dumping data for table erp_usi.suppliers: 3 rows
/*!40000 ALTER TABLE "suppliers" DISABLE KEYS */;
SET IDENTITY_INSERT suppliers on;
INSERT INTO "suppliers" ("id", "company_name", "state_registration", "person_id") VALUES
	(1, 'Forn1', '000999', 5),
	(2, 'Forn2', '000999', 6),
	(3, 'Forn3', '000999', 1);
	SET IDENTITY_INSERT suppliers off;
/*!40000 ALTER TABLE "suppliers" ENABLE KEYS */;

-- Dumping data for table erp_usi.telephones: 0 rows
/*!40000 ALTER TABLE "telephones" DISABLE KEYS */;
/*!40000 ALTER TABLE "telephones" ENABLE KEYS */;

-- Dumping data for table erp_usi.users: 0 rows
/*!40000 ALTER TABLE "users" DISABLE KEYS */;
/*!40000 ALTER TABLE "users" ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
