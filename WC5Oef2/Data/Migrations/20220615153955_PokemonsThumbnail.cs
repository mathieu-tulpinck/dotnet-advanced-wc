using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC5Oef2.Data.Migrations
{
    public partial class PokemonsThumbnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Thumbnail",
                schema: "dbo",
                table: "Pokemons",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                schema: "dbo",
                table: "Pokemons");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)32, (byte)36 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)3, (byte)12 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Lives", "Speed" },
                values: new object[] { (byte)56, (byte)69 });
        }
    }
}
