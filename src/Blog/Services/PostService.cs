using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.Data;
using Assignment.Data.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Blog.Services
{
	public class PostService
	{
		private readonly IApplicationDbContext applicationDbContext;
		public PostService(IApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public ICollection<Post> GetPosts()
		{
			var query = applicationDbContext.Posts.AsQueryable();

			query = query
				.Include(p => p.Author)
				.Include(p => p.Comments);

			var posts = query.ToList();

			return posts;
		}

		public Post GetPost(Guid id)
		{
			var post = applicationDbContext.Posts.FirstOrDefault(p => p.Id == id);

			if (post == null)
			{
				// TODO: throw appropirate exception later
				throw new Exception();
			}

			return post;
		}
	}
}
