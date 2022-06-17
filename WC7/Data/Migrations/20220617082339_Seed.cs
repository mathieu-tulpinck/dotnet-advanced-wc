using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC7.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Auditoria",
                columns: new[] { "Id", "Capacity" },
                values: new object[] { 2, 2000 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DirectorName", "Title" },
                values: new object[] { "test director 1", "test title 1" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorName", "Ranking", "Title" },
                values: new object[] { 2, "test director 2", (byte)80, "test title 2" });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 17, 12, 23, 38, 917, DateTimeKind.Local).AddTicks(3741), new DateTime(2022, 6, 17, 10, 23, 38, 917, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "AuditoriumId", "End", "MovieId", "Start" },
                values: new object[] { 2, 2, new DateTime(2022, 6, 18, 12, 23, 38, 917, DateTimeKind.Local).AddTicks(3741), 2, new DateTime(2022, 6, 18, 10, 23, 38, 917, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "AuditoriumId", "End", "MovieId", "Start" },
                values: new object[] { 3, 1, new DateTime(2022, 6, 24, 12, 23, 38, 917, DateTimeKind.Local).AddTicks(3741), 2, new DateTime(2022, 6, 24, 10, 23, 38, 917, DateTimeKind.Local).AddTicks(3741) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DirectorName", "Title" },
                values: new object[] { "test director", "test title" });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 17, 11, 28, 31, 668, DateTimeKind.Local).AddTicks(8814), new DateTime(2022, 6, 17, 9, 28, 31, 666, DateTimeKind.Local).AddTicks(769) });
        }
    }
}
