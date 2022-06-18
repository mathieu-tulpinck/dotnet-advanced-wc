using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC7.Data.Migrations
{
    public partial class AlterShoppingCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "ShoppingCartItems",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 18, 14, 10, 33, 55, DateTimeKind.Local).AddTicks(9846), new DateTime(2022, 6, 18, 12, 10, 33, 55, DateTimeKind.Local).AddTicks(9846) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 19, 14, 10, 33, 55, DateTimeKind.Local).AddTicks(9846), new DateTime(2022, 6, 19, 12, 10, 33, 55, DateTimeKind.Local).AddTicks(9846) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 25, 14, 10, 33, 55, DateTimeKind.Local).AddTicks(9846), new DateTime(2022, 6, 25, 12, 10, 33, 55, DateTimeKind.Local).AddTicks(9846) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Amount",
                table: "ShoppingCartItems",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 18, 14, 0, 44, 796, DateTimeKind.Local).AddTicks(675), new DateTime(2022, 6, 18, 12, 0, 44, 796, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 19, 14, 0, 44, 796, DateTimeKind.Local).AddTicks(675), new DateTime(2022, 6, 19, 12, 0, 44, 796, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 25, 14, 0, 44, 796, DateTimeKind.Local).AddTicks(675), new DateTime(2022, 6, 25, 12, 0, 44, 796, DateTimeKind.Local).AddTicks(675) });
        }
    }
}
