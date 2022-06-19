using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC7.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ee633f0-c515-423f-b198-c6ef8c988cad", "2da46e59-3081-47db-b4f7-01bf7ad83301", "admin", null },
                    { "72c83d01-f237-40c6-8e35-8886b1c014a2", "0ef164a0-b566-4a18-97c4-25bdcdf22215", "staff", null },
                    { "a46db731-c1e1-4404-93cd-89e2d3b4d96e", "0c897893-93a5-4315-a6eb-1f0d7a3af5c9", "user", null }
                });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 19, 16, 6, 40, 877, DateTimeKind.Local).AddTicks(9128), new DateTime(2022, 6, 19, 14, 6, 40, 877, DateTimeKind.Local).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 20, 16, 6, 40, 877, DateTimeKind.Local).AddTicks(9128), new DateTime(2022, 6, 20, 14, 6, 40, 877, DateTimeKind.Local).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 26, 16, 6, 40, 877, DateTimeKind.Local).AddTicks(9128), new DateTime(2022, 6, 26, 14, 6, 40, 877, DateTimeKind.Local).AddTicks(9128) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72c83d01-f237-40c6-8e35-8886b1c014a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ee633f0-c515-423f-b198-c6ef8c988cad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a46db731-c1e1-4404-93cd-89e2d3b4d96e");

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
    }
}
