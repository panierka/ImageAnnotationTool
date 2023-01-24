using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Shapes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Annotations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PointsX",
                table: "Annotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PointsY",
                table: "Annotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Annotations");

            migrationBuilder.DropColumn(
                name: "PointsX",
                table: "Annotations");

            migrationBuilder.DropColumn(
                name: "PointsY",
                table: "Annotations");
        }
    }
}
