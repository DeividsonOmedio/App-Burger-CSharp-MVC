using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCatergoryProductsAndImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 20, 11, 43, 10, 941, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 20, 11, 43, 10, 941, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Code", "Image" },
                values: new object[] { 0, new Guid("b6ee7bac-c94a-4206-b565-dfc23e9079e2"), "https://s3-sa-east-1.amazonaws.com/deliveryon-uploads/products/traillerdoserginho/76_55afa529b0ae0.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Code", "Image" },
                values: new object[] { 0, new Guid("3644a333-6de2-4fd6-8abf-6926ac341fb8"), "https://th.bing.com/th/id/OIP.EN4Iy0c2I5nYGZcORBKOsQHaHa?rs=1&pid=ImgDetMain" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Category", "Code", "Image", "Name", "Price" },
                values: new object[] { 3, 30, 1, new Guid("0bc1f2c9-fd31-4e4e-9821-62ddb619dd95"), "https://www.lojasliberty.com/images/products/941593087213_s.jpg", "Coca Cola", 5m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 9, 20, 11, 43, 10, 942, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 9, 20, 11, 43, 10, 942, DateTimeKind.Local).AddTicks(66));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 20, 11, 15, 45, 831, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 20, 11, 15, 45, 831, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Categoria", "Code" },
                values: new object[] { "", new Guid("5a07de7d-92ee-4050-b38e-928ac9786767") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Categoria", "Code" },
                values: new object[] { "", new Guid("f889d781-d5fa-408c-bbe5-b1b362dbdb69") });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 9, 20, 11, 15, 45, 831, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 9, 20, 11, 15, 45, 831, DateTimeKind.Local).AddTicks(9324));
        }
    }
}
