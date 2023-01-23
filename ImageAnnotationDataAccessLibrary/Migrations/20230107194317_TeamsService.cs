using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TeamsService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Teams");
        }
    }
}
