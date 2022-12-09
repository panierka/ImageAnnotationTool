using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.DataAccess
{
	public class ImageAnnotationToolContext : DbContext
	{
		public ImageAnnotationToolContext(DbContextOptions options) : base(options) { }

		public DbSet<UserAccount> UserAccounts { get; set; }

		public DbSet<ImageData> ImageDatas { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
