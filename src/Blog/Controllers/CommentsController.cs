using System;
using System.Collections.Generic;
using Assignment.Blog.Dto;
using Assignment.Blog.Services;
using Assignment.Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Blog.Controllers
{
	[Route(ApiVersion.Path + "blog/[controller]")]
	public class CommentsController : Controller
	{
		private readonly ICommentService commentService;

		public CommentsController(ICommentService commentService)
		{
			this.commentService = commentService;
		}

		/// <summary>Returns a list of comments associated with given post ID.</summary>
		/// <param name="postId">A post ID.</param>
		[HttpGet("{id}")]
		[Produces("application/json")]
		public ActionResult<IEnumerable<CommentDto>> GetCommentsByPostId(Guid postId)
		{
			var commentDtos = commentService.GetCommentsByPostId(postId);
			return Ok(commentDtos);
		}

		/// <summary>Creates a comment and returns its ID.</summary>
		/// <param name="commentDto">A comment object.</param>
		[HttpPost]
		public ActionResult<Guid> CreateComment([FromBody] CommentDto commentDto)
		{
			var createdCommentId = commentService.CreateComment(commentDto);

			return Created(string.Empty, createdCommentId);
		}

		/// <summary>Updates a comment and returns the updated comment.</summary>
		/// <param name="commentDto">A comment object.</param>
		[HttpPut]
		public ActionResult<CommentDto> UpdateComment([FromBody] CommentDto commentDto)
		{
			var updatedComment = commentService.UpdateComment(commentDto);

			return Ok(updatedComment);
		}

		/// <summary>Deletes a comment.</summary>
		/// <param name="id">A comment ID.</param>
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			commentService.DeleteComment(id);

			return NoContent();
		}
	}
}
