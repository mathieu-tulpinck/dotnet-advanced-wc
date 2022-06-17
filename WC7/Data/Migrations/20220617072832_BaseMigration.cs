using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC7.Data.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    Ranking = table.Column<byte>(nullable: false),
                    DirectorName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditoriumId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_Auditoria_AuditoriumId",
                        column: x => x.AuditoriumId,
                        principalTable: "Auditoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Auditoria",
                columns: new[] { "Id", "Capacity" },
                values: new object[] { 1, 1000 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorName", "Ranking", "Title" },
                values: new object[] { 1, "test director", (byte)80, "test title" });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "AuditoriumId", "End", "MovieId", "Start" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 17, 11, 28, 31, 668, DateTimeKind.Local).AddTicks(8814), 1, new DateTime(2022, 6, 17, 9, 28, 31, 666, DateTimeKind.Local).AddTicks(769) });

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_AuditoriumId",
                table: "Screenings",
                column: "AuditoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
