using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTableLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KurseLanguage",
                columns: table => new
                {
                    KurseId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KurseLanguage", x => new { x.KurseId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_KurseLanguage_Kurses_KurseId",
                        column: x => x.KurseId,
                        principalTable: "Kurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KurseLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KurseLanguage_LanguageId",
                table: "KurseLanguage",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KurseLanguage");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
