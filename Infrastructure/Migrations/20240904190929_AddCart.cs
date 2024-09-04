using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 4, 16, 9, 27, 472, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 4, 16, 9, 27, 472, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "User",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "User",
                value: "Dev");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: new Guid("2aaa63fa-9a3b-4e1a-abf1-d5b989ff8b75"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: new Guid("b40c63fa-096c-4858-902d-3b2d6e36b429"));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 9, 4, 16, 9, 27, 472, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 9, 4, 16, 9, 27, 472, DateTimeKind.Local).AddTicks(8214));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 2, 15, 50, 23, 764, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 2, 15, 50, 23, 764, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "User",
                value: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "User",
                value: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: new Guid("696828dd-35c8-46c0-b6cb-ca124cced891"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: new Guid("ebda01e8-d04f-485c-b658-f9eaf09d4c38"));

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SaleProduct",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 9, 2, 15, 50, 23, 764, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 9, 2, 15, 50, 23, 764, DateTimeKind.Local).AddTicks(2601));
        }
    }
}
