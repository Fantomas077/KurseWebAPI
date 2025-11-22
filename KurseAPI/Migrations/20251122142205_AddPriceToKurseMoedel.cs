using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToKurseMoedel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Kurses",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Kurses");
        }
    }
}
