using System;
using System.Linq;
using Assignment.Data.Entities;
using Assignment.Data.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Post> Posts { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Author> Authors { get; set; }

		public override int SaveChanges()
		{
			AddTimeStamps();
			return base.SaveChanges();
		}

		private void AddTimeStamps()
		{
			var trackables = ChangeTracker.Entries<ITrackableEntity>();
			var now = DateTimeOffset.Now;
			if (trackables != null)
			{
				// added
				foreach (var item in trackables.Where(t => t.State == EntityState.Added))
				{
					item.Entity.CreatedDateTime = now;
					item.Entity.UpdatedDateTime = now;
				}
				// modified
				foreach (var item in trackables.Where(t => t.State == EntityState.Modified))
				{
					item.Property("CreatedDateTime").IsModified = false;
					item.Entity.UpdatedDateTime = now;
				}
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Author>()
				.HasIndex(a => a.Name)
				.IsUnique();
		}
	}
}
