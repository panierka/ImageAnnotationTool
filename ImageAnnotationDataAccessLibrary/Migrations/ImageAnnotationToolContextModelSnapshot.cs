﻿// <auto-generated />
using System;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImageAnnotationToolDataAccessLibrary.Migrations
{
    [DbContext(typeof(ImageAnnotationToolContext))]
    partial class ImageAnnotationToolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.AnnotatedImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ImageDataId")
                        .HasColumnType("int");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageDataId");

                    b.HasIndex("JobId");

                    b.HasIndex("ProjectId");

                    b.ToTable("AnnotatedImages");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.ImageData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageDatas");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedProjectMemberId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedProjectMemberId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.ProjectMemberSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedTeamMemberId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedTeamMemberId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectMemberSeats");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.TeamMemberSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedUserId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMemberSeats");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.AnnotatedImage", b =>
                {
                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.ImageData", "ImageData")
                        .WithMany()
                        .HasForeignKey("ImageDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Job", "Job")
                        .WithMany("AnnotatedImages")
                        .HasForeignKey("JobId");

                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Project", "Project")
                        .WithMany("AnnotatedImages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageData");

                    b.Navigation("Job");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Job", b =>
                {
                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.ProjectMemberSeat", "AssignedProjectMember")
                        .WithMany("Jobs")
                        .HasForeignKey("AssignedProjectMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AssignedProjectMember");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Project", b =>
                {
                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Team", "Team")
                        .WithMany("Projects")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.ProjectMemberSeat", b =>
                {
                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.TeamMemberSeat", "AssignedTeamMember")
                        .WithMany("ProjectMemberSeats")
                        .HasForeignKey("AssignedTeamMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Project", null)
                        .WithMany("Members")
                        .HasForeignKey("ProjectId");

                    b.Navigation("AssignedTeamMember");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.TeamMemberSeat", b =>
                {
                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.UserAccount", "AssignedUser")
                        .WithMany("TeamMemberSeats")
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedUser");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Job", b =>
                {
                    b.Navigation("AnnotatedImages");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Project", b =>
                {
                    b.Navigation("AnnotatedImages");

                    b.Navigation("Jobs");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.ProjectMemberSeat", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.Team", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.TeamMemberSeat", b =>
                {
                    b.Navigation("ProjectMemberSeats");
                });

            modelBuilder.Entity("ImageAnnotationToolDataAccessLibrary.Models.TeamManagement.UserAccount", b =>
                {
                    b.Navigation("TeamMemberSeats");
                });
#pragma warning restore 612, 618
        }
    }
}
