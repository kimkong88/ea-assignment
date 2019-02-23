using Assignment.Data.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
	public interface IApplicationDbContext
	{
		DbSet<Author> Authors { get; set; }
		DbSet<Comment> Comments { get; set; }
		DbSet<Post> Posts { get; set; }

		int SaveChanges();
	}
}
