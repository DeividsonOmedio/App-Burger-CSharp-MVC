using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesNasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "SaleProduct",
                newName: "Amount");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Amount", "MaterialId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2m, 1, 1 },
                    { 2, 1m, 2, 1 },
                    { 3, 0.200m, 3, 1 },
                    { 4, 1m, 4, 1 },
                    { 6, 1m, 1, 2 },
                    { 7, 1m, 2, 2 },
                    { 8, 0.300m, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Amount", "MinimumQuantity", "Name", "PurchasePrice" },
                values: new object[] { 5, 2000m, 200m, "Ovo", 0.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name", "Price" },
                values: new object[] { new Guid("696828dd-35c8-46c0-b6cb-ca124cced891"), "X-Tudo", 20m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Name", "Price" },
                values: new object[] { new Guid("ebda01e8-d04f-485c-b658-f9eaf09d4c38"), "X-Egg-Bacon", 18m });

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

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Amount", "MaterialId", "ProductId" },
                values: new object[] { 5, 2m, 5, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MaterialId",
                table: "Ingredients",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ProductId",
                table: "Ingredients",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "SaleProduct",
                newName: "Quantidade");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredIn",
                value: new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name", "Price" },
                values: new object[] { new Guid("c4b2ae3a-e4e5-4bf5-b886-408d29e0bd82"), "Product 1", 200m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Name", "Price" },
                values: new object[] { new Guid("cc93c19c-3900-4a19-b7c6-a4ce00f56dde"), "Product 2", 300m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 9, 2, 10, 18, 20, 241, DateTimeKind.Local).AddTicks(4499));
        }
    }
}
