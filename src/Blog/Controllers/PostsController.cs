using System;
using System.Collections.Generic;
using Assignment.Blog.Dto;
using Assignment.Blog.Services;
using Assignment.Common.Constants;
using Assignment.Data.Entities.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Blog.Controllers
{
	[Route(ApiVersion.Path + "blog/[controller]")]
	public class PostsController : Controller
	{
		private readonly IPostService postService;

		public PostsController(IPostService postService)
		{
			this.postService = postService;
		}

		/// <summary>Returns a list of all posts</summary>
		[HttpGet]
		[Produces("application/json")]
		public ActionResult<IEnumerable<PostDto>> GetPosts()
		{
			var posts = postService.GetPosts();

			return Json(posts);
		}

		/// <summary>Returns a individual post.</summary>
		/// <param name="id">A post ID.</param>
		[HttpGet("{id}")]
		[Produces("application/json")]
		public ActionResult<Post> GetPost(Guid id)
		{
			var post = postService.GetPost(id);
			return Ok(post);
		}

		/// <summary>Creates a post and returns its ID.</summary>
		/// <param name="postDto">A post object.</param>
		[HttpPost]
		public ActionResult<Guid> CreatePost([FromBody] PostDto postDto)
		{
			var createdPostId = postService.CreatePost(postDto);

			return Created(string.Empty, createdPostId);
		}

		/// <summary>Updates a post and returns the updated post.</summary>
		/// <param name="postDto">A post object.</param>
		[HttpPut]
		public ActionResult<Post> UpdatePost([FromBody] PostDto postDto)
		{
			var updatedPost = postService.UpdatePost(postDto);

			return Ok(updatedPost);
		}

		/// <summary>Delets a post.</summary>
		/// <param name="id">A post ID.</param>
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			postService.DeletePost(id);

			return NoContent();
		}
	}
}
