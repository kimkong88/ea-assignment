using System;
using System.Collections.Generic;
using Assignment.Blog.Dto;

namespace Assignment.Blog.Services
{
	public interface IPostService
	{
		Guid? CreatePost(PostDto postDto);

		void DeletePost(Guid id);

		PostDto GetPost(Guid id);

		IEnumerable<PostDto> GetPosts();

		PostDto UpdatePost(PostDto postDto);
	}
}
