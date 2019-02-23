﻿using System;
using System.Collections.Generic;
using Assignment.Blog.Services;
using Assignment.Data.Entities.Blog;
using Common.Constants;
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
		public ActionResult<IList<Post>> GetPosts()
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
		/// <param name="post">A post object.</param>
		[HttpPost]
		public ActionResult<Guid> CreatePost([FromBody] Post post)
		{
			var createdPostId = postService.CreatePost(post);

			return Created(string.Empty, createdPostId);
		}

		/// <summary>Updates a post and returns the updated post.</summary>
		/// <param name="post">A post object.</param>
		[HttpPut, Route("{id}")]
		public ActionResult<Post> UpdatePost([FromBody] Post post)
		{
			var updatedPost = postService.UpdatePost(post);

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