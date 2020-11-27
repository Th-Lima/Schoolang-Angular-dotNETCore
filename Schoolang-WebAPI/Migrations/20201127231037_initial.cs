using Microsoft.EntityFrameworkCore.Migrations;

namespace Schoolang_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLanguages",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLanguages", x => new { x.StudentId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_StudentLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLanguages_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cellphone", "Name", "Surname" },
                values: new object[] { 1, "33225555", "Marta", "Kent" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cellphone", "Name", "Surname" },
                values: new object[] { 2, "3354288", "Paula", "Isabela" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cellphone", "Name", "Surname" },
                values: new object[] { 3, "55668899", "Laura", "Antonia" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cellphone", "Name", "Surname" },
                values: new object[] { 4, "6565659", "Luiza", "Maria" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cellphone", "Name", "Surname" },
                values: new object[] { 5, "565685415", "Lucas", "Machado" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cellphone", "Name", "Surname" },
                values: new object[] { 6, "456454545", "Pedro", "Alvares" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cellphone", "Name", "Surname" },
                values: new object[] { 7, "9874512", "Paulo", "José" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Lauro" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Roberto" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 1, "Francês", 1 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 2, "Italiano", 2 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 3, "Português", 3 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 4, "Inglês", 4 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 5, "Alemão", 5 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "StudentLanguages",
                columns: new[] { "StudentId", "LanguageId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_TeacherId",
                table: "Languages",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLanguages_LanguageId",
                table: "StudentLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
