using ImageAnnotationToolDataAccessLibrary.Models.ExifExtraction;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ImageAnnotationToolDataAccessLibrary.DataAccess
{
	public class ImageAnnotationToolContext : DbContext
	{
		public ImageAnnotationToolContext(DbContextOptions options) : base(options) { }

		public DbSet<AnnotatedImage> AnnotatedImages { get; set; }
        public DbSet<ImageData> ImageDatas { get; set; }
		public DbSet<Job> Jobs { get; set; }

		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectMemberSeat> ProjectMemberSeats { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<TeamMemberSeat> TeamMemberSeats { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

		public DbSet<Annotation> Annotations { get; set; }
		public DbSet<AnnotationClass> AnnotationClasses { get; set; }
		public DbSet<Descriptor> Descriptors { get; set; }
		public DbSet<DescriptorBlueprint> DescriptorBlueprints { get; set; }

		public DbSet<Exif> Exifs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Job>()
				.HasOne(x => x.Project)
				.WithMany(x => x.Jobs)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<UserAccount>()
				.HasIndex(x => x.Login)
				.IsUnique();

            modelBuilder.Entity<Annotation>()
                .HasOne(x => x.Class)
                .WithMany(x => x.AnnotationsWithClass)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Descriptor>()
                .HasOne(x => x.Blueprint)
                .WithMany(x => x.CreatedDescriptors)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectMemberSeat>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Members)
                .OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<ImageData>()
				.HasOne(i => i.Exif)
				.WithOne(e => e.ImageData)
				.HasForeignKey<Exif>(e => e.ImageDataForeignKey);

			modelBuilder.Entity<ImageData>()
				.HasOne(i => i.AnnotatedImage)
				.WithOne(e => e.ImageData)
				.HasForeignKey<AnnotatedImage>(e => e.ImageDataForeignKey);

            modelBuilder.Entity<Annotation>()
				.Property(e => e.PointsX)
				.HasConversion(
					v => string.Join(';', v),
					v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList());

            modelBuilder.Entity<Annotation>()
				 .Property(e => e.PointsY)
				 .HasConversion(
				  v => string.Join(';', v),
			      v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList());
        }
	}
}
