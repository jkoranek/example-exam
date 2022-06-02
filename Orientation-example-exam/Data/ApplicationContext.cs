using System;
using Orientation_example_exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Orientation_example_exam.Data
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasKey(p => p.Id);
			modelBuilder.Entity<User>().Property(p => p.Alias).HasColumnType("varchar(30)").IsRequired(true);
			modelBuilder.Entity<User>().Property(p => p.Url).HasColumnType("varchar(50)").IsRequired(true);
			modelBuilder.Entity<User>().Property(p => p.SecretCode).HasColumnType("varchar(4)");
			modelBuilder.Entity<User>().Property(p => p.HitCount).HasColumnType("int");
		}
	}
}