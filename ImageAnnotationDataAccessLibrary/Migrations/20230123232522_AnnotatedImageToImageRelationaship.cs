using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AnnotatedImageToImageRelationaship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImages_ImageDatas_ImageDataId",
                table: "AnnotatedImages");

            migrationBuilder.DropIndex(
                name: "IX_AnnotatedImages_ImageDataId",
                table: "AnnotatedImages");

            migrationBuilder.RenameColumn(
                name: "ImageDataId",
                table: "AnnotatedImages",
                newName: "ImageDataForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotatedImages_ImageDataForeignKey",
                table: "AnnotatedImages",
                column: "ImageDataForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImages_ImageDatas_ImageDataForeignKey",
                table: "AnnotatedImages",
                column: "ImageDataForeignKey",
                principalTable: "ImageDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImages_ImageDatas_ImageDataForeignKey",
                table: "AnnotatedImages");

            migrationBuilder.DropIndex(
                name: "IX_AnnotatedImages_ImageDataForeignKey",
                table: "AnnotatedImages");

            migrationBuilder.RenameColumn(
                name: "ImageDataForeignKey",
                table: "AnnotatedImages",
                newName: "ImageDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnotatedImages_ImageDataId",
                table: "AnnotatedImages",
                column: "ImageDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImages_ImageDatas_ImageDataId",
                table: "AnnotatedImages",
                column: "ImageDataId",
                principalTable: "ImageDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
