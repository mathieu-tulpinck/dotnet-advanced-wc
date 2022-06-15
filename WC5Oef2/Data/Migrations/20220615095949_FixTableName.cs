using Microsoft.EntityFrameworkCore.Migrations;

namespace WC5Oef2.Data.Migrations
{
    public partial class FixTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_AspNetUsers_TrainerId",
                table: "Pokemon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemon",
                table: "Pokemon");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Pokemon",
                newName: "Pokemons",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemon_TrainerId",
                schema: "dbo",
                table: "Pokemons",
                newName: "IX_Pokemons_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemons",
                schema: "dbo",
                table: "Pokemons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_AspNetUsers_TrainerId",
                schema: "dbo",
                table: "Pokemons",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_AspNetUsers_TrainerId",
                schema: "dbo",
                table: "Pokemons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemons",
                schema: "dbo",
                table: "Pokemons");

            migrationBuilder.RenameTable(
                name: "Pokemons",
                schema: "dbo",
                newName: "Pokemon");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemons_TrainerId",
                table: "Pokemon",
                newName: "IX_Pokemon_TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemon",
                table: "Pokemon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_AspNetUsers_TrainerId",
                table: "Pokemon",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
