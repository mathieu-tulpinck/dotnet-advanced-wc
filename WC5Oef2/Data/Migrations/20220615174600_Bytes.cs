using Microsoft.EntityFrameworkCore.Migrations;

namespace WC5Oef2.Data.Migrations
{
    public partial class Bytes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)32, (byte)79 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)93, (byte)20 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)91, (byte)28 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)89, (byte)16 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)0, (byte)2 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)64, (byte)29 });
        }
    }
}
