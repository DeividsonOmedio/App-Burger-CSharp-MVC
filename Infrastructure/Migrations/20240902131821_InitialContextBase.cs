using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialContextBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    RegisteredIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypePayment = table.Column<int>(type: "int", nullable: false),
                    StatusSale = table.Column<int>(type: "int", nullable: false),
                    StatusPayment = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => new { x.SaleId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SaleProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DataBirth", "Email", "Name", "PhoneNumber", "RegisteredIn" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 1, 1), "client1@example.com", "Client 1", "12345678901", new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(3098) },
                    { 2, new DateOnly(1985, 5, 10), "client2@example.com", "Client 2", "09876543210", new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(3129) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Function", "Name", "Password", "User" },
                values: new object[,]
                {
                    { 1, 2, "Employee 1", "Dev@123", "" },
                    { 2, 0, "Employee 2", "Dev@123", "" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Amount", "MinimumQuantity", "Name", "PurchasePrice" },
                values: new object[,]
                {
                    { 1, 100m, 20m, "Bife Bovino", 1.50m },
                    { 2, 100m, 20m, "Pao de Hamburguer", 1.00m },
                    { 3, 2000m, 200m, "Bacon", 1.00m },
                    { 4, 2000m, 200m, "Cheddar", 1.00m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Code", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10, new Guid("c4b2ae3a-e4e5-4bf5-b886-408d29e0bd82"), "Product 1", 200m },
                    { 2, 15, new Guid("cc93c19c-3900-4a19-b7c6-a4ce00f56dde"), "Product 2", 300m }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "ClientId", "Discount", "EmployeeId", "SaleDate", "StatusPayment", "StatusSale", "TotalValue", "TypePayment" },
                values: new object[,]
                {
                    { 1, 1, 0m, 1, new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(4483), 1, 4, 400m, 3 },
                    { 2, 2, 50m, 2, new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(4499), 0, 0, 600m, 1 }
                });

            migrationBuilder.InsertData(
                table: "SaleProduct",
                columns: new[] { "ProductId", "SaleId", "Id", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, 0, 2 },
                    { 2, 1, 0, 1 },
                    { 1, 2, 0, 1 },
                    { 2, 2, 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_ProductId",
                table: "SaleProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
