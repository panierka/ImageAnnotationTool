using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Exif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "ImageDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "ImageDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exifs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageDataForeignKey = table.Column<int>(type: "int", nullable: false),
                    ExifVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorSpace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aperture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExposureTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FocalLenght = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitalZoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brightness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatitudeRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongitudeRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exifs_ImageDatas_ImageDataForeignKey",
                        column: x => x.ImageDataForeignKey,
                        principalTable: "ImageDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exifs_ImageDataForeignKey",
                table: "Exifs",
                column: "ImageDataForeignKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exifs");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "ImageDatas");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "ImageDatas");
        }
    }
}
