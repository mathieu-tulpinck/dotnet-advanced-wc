using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC7.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 19, 15, 41, 39, 892, DateTimeKind.Local).AddTicks(4153), new DateTime(2022, 6, 19, 13, 41, 39, 892, DateTimeKind.Local).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 20, 15, 41, 39, 892, DateTimeKind.Local).AddTicks(4153), new DateTime(2022, 6, 20, 13, 41, 39, 892, DateTimeKind.Local).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 26, 15, 41, 39, 892, DateTimeKind.Local).AddTicks(4153), new DateTime(2022, 6, 26, 13, 41, 39, 892, DateTimeKind.Local).AddTicks(4153) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
