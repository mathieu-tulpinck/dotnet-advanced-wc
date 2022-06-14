using Microsoft.EntityFrameworkCore.Migrations;

namespace WC3Oef3.Data.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studenten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vakken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Punten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VakId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punten_Studenten_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Punten_Vakken_VakId",
                        column: x => x.VakId,
                        principalTable: "Vakken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Studenten",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { 1, "Paul" },
                    { 2, "Marvin" },
                    { 3, "Michael" },
                    { 4, "Amber" },
                    { 5, "Anna" },
                    { 6, "Belle" },
                    { 7, "Carrie" },
                    { 8, "Wim" }
                });

            migrationBuilder.InsertData(
                table: "Vakken",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { 1, ".NET Essentials" },
                    { 2, ".NET Advanced" },
                    { 3, "Programming Essentials" },
                    { 4, "Programming Advanced" },
                    { 5, "Data Essentials" },
                    { 6, "Data Advanced" }
                });

            migrationBuilder.InsertData(
                table: "Punten",
                columns: new[] { "Id", "Score", "StudentId", "VakId" },
                values: new object[] { 1, 20, 8, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Punten_StudentId",
                table: "Punten",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Punten_VakId",
                table: "Punten",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_Vakken_Naam",
                table: "Vakken",
                column: "Naam",
                unique: true,
                filter: "[Naam] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punten");

            migrationBuilder.DropTable(
                name: "Studenten");

            migrationBuilder.DropTable(
                name: "Vakken");
        }
    }
}
