using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddKurseKaufderenRealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "Käufe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Käufe_KursId",
                table: "Käufe",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Käufe_Kurses_KursId",
                table: "Käufe",
                column: "KursId",
                principalTable: "Kurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Käufe_Kurses_KursId",
                table: "Käufe");

            migrationBuilder.DropIndex(
                name: "IX_Käufe_KursId",
                table: "Käufe");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "Käufe");
        }
    }
}
