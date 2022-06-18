using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WC7.Data.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningId = table.Column<int>(nullable: false),
                    Amount = table.Column<byte>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Capacity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 2,
                column: "Capacity",
                value: 50);

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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ScreeningId",
                table: "ShoppingCartItems",
                column: "ScreeningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.UpdateData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Capacity",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Auditoria",
                keyColumn: "Id",
                keyValue: 2,
                column: "Capacity",
                value: 2000);

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
    }
}
