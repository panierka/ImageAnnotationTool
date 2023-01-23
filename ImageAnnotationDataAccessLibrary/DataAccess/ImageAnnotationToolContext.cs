using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;

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

   //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   //     {
			//optionsBuilder.UseLazyLoadingProxies();
   //     }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Job>()
				.HasOne(x => x.Project)
				.WithMany(x => x.Jobs)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<UserAccount>()
				.HasIndex(x => x.Login)
				.IsUnique();
		}
	}
}
