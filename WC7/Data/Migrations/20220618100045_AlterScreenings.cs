using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC7.Data.Migrations
{
    public partial class AlterScreenings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Screenings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableSeats", "End", "Start" },
                values: new object[] { 10, new DateTime(2022, 6, 18, 14, 0, 44, 796, DateTimeKind.Local).AddTicks(675), new DateTime(2022, 6, 18, 12, 0, 44, 796, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableSeats", "End", "Start" },
                values: new object[] { 50, new DateTime(2022, 6, 19, 14, 0, 44, 796, DateTimeKind.Local).AddTicks(675), new DateTime(2022, 6, 19, 12, 0, 44, 796, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableSeats", "End", "Start" },
                values: new object[] { 10, new DateTime(2022, 6, 25, 14, 0, 44, 796, DateTimeKind.Local).AddTicks(675), new DateTime(2022, 6, 25, 12, 0, 44, 796, DateTimeKind.Local).AddTicks(675) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Screenings");

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 17, 17, 34, 18, 455, DateTimeKind.Local).AddTicks(3818), new DateTime(2022, 6, 17, 15, 34, 18, 455, DateTimeKind.Local).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 18, 17, 34, 18, 455, DateTimeKind.Local).AddTicks(3818), new DateTime(2022, 6, 18, 15, 34, 18, 455, DateTimeKind.Local).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 34, 18, 455, DateTimeKind.Local).AddTicks(3818), new DateTime(2022, 6, 24, 15, 34, 18, 455, DateTimeKind.Local).AddTicks(3818) });
        }
    }
}
