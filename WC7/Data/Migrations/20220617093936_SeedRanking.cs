using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC7.Data.Migrations
{
    public partial class SeedRanking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ranking",
                value: (byte)100);

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 17, 13, 39, 36, 109, DateTimeKind.Local).AddTicks(9024), new DateTime(2022, 6, 17, 11, 39, 36, 109, DateTimeKind.Local).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 18, 13, 39, 36, 109, DateTimeKind.Local).AddTicks(9024), new DateTime(2022, 6, 18, 11, 39, 36, 109, DateTimeKind.Local).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 24, 13, 39, 36, 109, DateTimeKind.Local).AddTicks(9024), new DateTime(2022, 6, 24, 11, 39, 36, 109, DateTimeKind.Local).AddTicks(9024) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ranking",
                value: (byte)80);

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 17, 12, 23, 38, 917, DateTimeKind.Local).AddTicks(3741), new DateTime(2022, 6, 17, 10, 23, 38, 917, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 18, 12, 23, 38, 917, DateTimeKind.Local).AddTicks(3741), new DateTime(2022, 6, 18, 10, 23, 38, 917, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 24, 12, 23, 38, 917, DateTimeKind.Local).AddTicks(3741), new DateTime(2022, 6, 24, 10, 23, 38, 917, DateTimeKind.Local).AddTicks(3741) });
        }
    }
}
