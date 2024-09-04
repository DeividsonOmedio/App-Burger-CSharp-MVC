using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCartToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "Id", "Amount", "ClientId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: new Guid("9e93f7be-7fc5-4e22-a401-79a587405315"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: new Guid("6118bb44-5cd2-4ec3-bc97-b930b520949e"));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientId",
                table: "Cart",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

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
    }
}
