using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "MyProperty", "Name", "Price", "Stock" },
                values: new object[] { 1, new DateTime(2024, 2, 23, 13, 38, 46, 518, DateTimeKind.Local).AddTicks(8548), null, 0, "Bilgisayar", 15000m, 300 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "MyProperty", "Name", "Price", "Stock" },
                values: new object[] { 2, new DateTime(2024, 2, 24, 13, 38, 46, 520, DateTimeKind.Local).AddTicks(6020), null, 0, "Televizyon", 19000m, 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "MyProperty", "Name", "Price", "Stock" },
                values: new object[] { 3, new DateTime(2024, 2, 1, 13, 38, 46, 520, DateTimeKind.Local).AddTicks(6041), null, 0, "Klavye", 900m, 500 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
