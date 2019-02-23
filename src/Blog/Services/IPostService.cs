using System;
using System.Collections.Generic;
using Assignment.Data.Entities.Blog;

namespace Assignment.Blog.Services
{
	public interface IPostService
	{
		Guid CreatePost(Post post);
		void DeletePost(Guid id);
		Post GetPost(Guid id);
		ICollection<Post> GetPosts();
		Post UpdatePost(Post post);
	}
}