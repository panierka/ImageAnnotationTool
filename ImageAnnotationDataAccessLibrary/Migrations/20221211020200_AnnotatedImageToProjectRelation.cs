using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AnnotatedImageToProjectRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImage_ImageDatas_ImageDataId",
                table: "AnnotatedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImage_Job_JobId",
                table: "AnnotatedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImage_Project_ProjectId",
                table: "AnnotatedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_ProjectMemberSeat_AssignedProjectMemberId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Project_ProjectId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Team_TeamId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMemberSeat_Project_ProjectId",
                table: "ProjectMemberSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMemberSeat_TeamMemberSeat_AssignedTeamMemberId",
                table: "ProjectMemberSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMemberSeat_Team_TeamId",
                table: "TeamMemberSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMemberSeat_UserAccounts_AssignedUserId",
                table: "TeamMemberSeat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMemberSeat",
                table: "TeamMemberSeat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectMemberSeat",
                table: "ProjectMemberSeat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnnotatedImage",
                table: "AnnotatedImage");

            migrationBuilder.RenameTable(
                name: "TeamMemberSeat",
                newName: "TeamMemberSeats");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "ProjectMemberSeat",
                newName: "ProjectMemberSeats");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "AnnotatedImage",
                newName: "AnnotatedImages");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMemberSeat_TeamId",
                table: "TeamMemberSeats",
                newName: "IX_TeamMemberSeats_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMemberSeat_AssignedUserId",
                table: "TeamMemberSeats",
                newName: "IX_TeamMemberSeats_AssignedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMemberSeat_ProjectId",
                table: "ProjectMemberSeats",
                newName: "IX_ProjectMemberSeats_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMemberSeat_AssignedTeamMemberId",
                table: "ProjectMemberSeats",
                newName: "IX_ProjectMemberSeats_AssignedTeamMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_TeamId",
                table: "Projects",
                newName: "IX_Projects_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_ProjectId",
                table: "Jobs",
                newName: "IX_Jobs_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_AssignedProjectMemberId",
                table: "Jobs",
                newName: "IX_Jobs_AssignedProjectMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnotatedImage_ProjectId",
                table: "AnnotatedImages",
                newName: "IX_AnnotatedImages_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnotatedImage_JobId",
                table: "AnnotatedImages",
                newName: "IX_AnnotatedImages_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnotatedImage_ImageDataId",
                table: "AnnotatedImages",
                newName: "IX_AnnotatedImages_ImageDataId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "AnnotatedImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "AnnotatedImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMemberSeats",
                table: "TeamMemberSeats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectMemberSeats",
                table: "ProjectMemberSeats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnnotatedImages",
                table: "AnnotatedImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImages_ImageDatas_ImageDataId",
                table: "AnnotatedImages",
                column: "ImageDataId",
                principalTable: "ImageDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImages_Jobs_JobId",
                table: "AnnotatedImages",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImages_Projects_ProjectId",
                table: "AnnotatedImages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_ProjectMemberSeats_AssignedProjectMemberId",
                table: "Jobs",
                column: "AssignedProjectMemberId",
                principalTable: "ProjectMemberSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Projects_ProjectId",
                table: "Jobs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMemberSeats_Projects_ProjectId",
                table: "ProjectMemberSeats",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMemberSeats_TeamMemberSeats_AssignedTeamMemberId",
                table: "ProjectMemberSeats",
                column: "AssignedTeamMemberId",
                principalTable: "TeamMemberSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMemberSeats_Teams_TeamId",
                table: "TeamMemberSeats",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMemberSeats_UserAccounts_AssignedUserId",
                table: "TeamMemberSeats",
                column: "AssignedUserId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImages_ImageDatas_ImageDataId",
                table: "AnnotatedImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImages_Jobs_JobId",
                table: "AnnotatedImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnotatedImages_Projects_ProjectId",
                table: "AnnotatedImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_ProjectMemberSeats_AssignedProjectMemberId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Projects_ProjectId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMemberSeats_Projects_ProjectId",
                table: "ProjectMemberSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMemberSeats_TeamMemberSeats_AssignedTeamMemberId",
                table: "ProjectMemberSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMemberSeats_Teams_TeamId",
                table: "TeamMemberSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMemberSeats_UserAccounts_AssignedUserId",
                table: "TeamMemberSeats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMemberSeats",
                table: "TeamMemberSeats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectMemberSeats",
                table: "ProjectMemberSeats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnnotatedImages",
                table: "AnnotatedImages");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "TeamMemberSeats",
                newName: "TeamMemberSeat");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "ProjectMemberSeats",
                newName: "ProjectMemberSeat");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "AnnotatedImages",
                newName: "AnnotatedImage");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMemberSeats_TeamId",
                table: "TeamMemberSeat",
                newName: "IX_TeamMemberSeat_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMemberSeats_AssignedUserId",
                table: "TeamMemberSeat",
                newName: "IX_TeamMemberSeat_AssignedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_TeamId",
                table: "Project",
                newName: "IX_Project_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMemberSeats_ProjectId",
                table: "ProjectMemberSeat",
                newName: "IX_ProjectMemberSeat_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMemberSeats_AssignedTeamMemberId",
                table: "ProjectMemberSeat",
                newName: "IX_ProjectMemberSeat_AssignedTeamMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_ProjectId",
                table: "Job",
                newName: "IX_Job_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_AssignedProjectMemberId",
                table: "Job",
                newName: "IX_Job_AssignedProjectMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnotatedImages_ProjectId",
                table: "AnnotatedImage",
                newName: "IX_AnnotatedImage_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnotatedImages_JobId",
                table: "AnnotatedImage",
                newName: "IX_AnnotatedImage_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_AnnotatedImages_ImageDataId",
                table: "AnnotatedImage",
                newName: "IX_AnnotatedImage_ImageDataId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "AnnotatedImage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "AnnotatedImage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMemberSeat",
                table: "TeamMemberSeat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectMemberSeat",
                table: "ProjectMemberSeat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnnotatedImage",
                table: "AnnotatedImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImage_ImageDatas_ImageDataId",
                table: "AnnotatedImage",
                column: "ImageDataId",
                principalTable: "ImageDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImage_Job_JobId",
                table: "AnnotatedImage",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnotatedImage_Project_ProjectId",
                table: "AnnotatedImage",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_ProjectMemberSeat_AssignedProjectMemberId",
                table: "Job",
                column: "AssignedProjectMemberId",
                principalTable: "ProjectMemberSeat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Project_ProjectId",
                table: "Job",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Team_TeamId",
                table: "Project",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMemberSeat_Project_ProjectId",
                table: "ProjectMemberSeat",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMemberSeat_TeamMemberSeat_AssignedTeamMemberId",
                table: "ProjectMemberSeat",
                column: "AssignedTeamMemberId",
                principalTable: "TeamMemberSeat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMemberSeat_Team_TeamId",
                table: "TeamMemberSeat",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMemberSeat_UserAccounts_AssignedUserId",
                table: "TeamMemberSeat",
                column: "AssignedUserId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
