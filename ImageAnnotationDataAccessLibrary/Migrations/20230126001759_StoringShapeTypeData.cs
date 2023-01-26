using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class StoringShapeTypeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShapeType",
                table: "Annotations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShapeType",
                table: "Annotations");
        }
    }
}
