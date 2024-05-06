using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBooking.Migrations
{
    /// <inheritdoc />
    public partial class show : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Shows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
