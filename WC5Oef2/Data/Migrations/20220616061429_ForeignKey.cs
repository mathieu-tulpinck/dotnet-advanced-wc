using Microsoft.EntityFrameworkCore.Migrations;

namespace WC5Oef2.Data.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)4, (byte)60 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)29, (byte)5 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)43, (byte)99 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
