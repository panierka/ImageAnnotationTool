using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Annotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImages_Projects_ProjectId",
                table: "AnnotatedImages");

            migrationBuilder.DropIndex(
                name: "IX_AnnotatedImages_ProjectId",
                table: "AnnotatedImages");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "AnnotatedImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "AnnotatedImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnnotatedImages_ProjectId",
                table: "AnnotatedImages",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImages_Projects_ProjectId",
                table: "AnnotatedImages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
