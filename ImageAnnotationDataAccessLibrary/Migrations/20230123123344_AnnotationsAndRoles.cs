using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AnnotationsAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "TeamMemberSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectMemberSeats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "ProjectMemberSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnnotationClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnotationClasses_Projects_ParentProjectId",
                        column: x => x.ParentProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annotations_AnnotatedImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "AnnotatedImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annotations_AnnotationClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "AnnotationClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DescriptorBlueprints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptorBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptorBlueprints_AnnotationClasses_ParentClassId",
                        column: x => x.ParentClassId,
                        principalTable: "AnnotationClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Descriptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnotationId = table.Column<int>(type: "int", nullable: false),
                    BlueprintId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptors_Annotations_AnnotationId",
                        column: x => x.AnnotationId,
                        principalTable: "Annotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptors_DescriptorBlueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "DescriptorBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationClasses_ParentProjectId",
                table: "AnnotationClasses",
                column: "ParentProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_ClassId",
                table: "Annotations",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_ImageId",
                table: "Annotations",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorBlueprints_ParentClassId",
                table: "DescriptorBlueprints",
                column: "ParentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptors_AnnotationId",
                table: "Descriptors",
                column: "AnnotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptors_BlueprintId",
                table: "Descriptors",
                column: "BlueprintId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptors");

            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "DescriptorBlueprints");

            migrationBuilder.DropTable(
                name: "AnnotationClasses");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "TeamMemberSeats");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ProjectMemberSeats");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectMemberSeats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
