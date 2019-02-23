using Assignment.Data.Entities.Post;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Post> Posts { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<PostComment> PostComments { get; set; }

		public DbSet<Author> Authors { get; set; }
	}
}
