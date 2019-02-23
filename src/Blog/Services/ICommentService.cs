using System;
using System.Collections.Generic;
using Assignment.Blog.Dto;

namespace Assignment.Blog.Services
{
	public interface ICommentService
	{
		Guid? CreateComment(CommentDto commentDto);
		void DeleteComment(Guid id);
		CommentDto GetComment(Guid? id);
		IEnumerable<CommentDto> GetCommentsByPostId(Guid postId);
		CommentDto UpdateComment(CommentDto commentDto);
	}
}