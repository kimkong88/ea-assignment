using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.Blog.Dto;
using Assignment.Common.Helpers;
using Assignment.Data;
using Assignment.Data.Entities.Blog;
using AutoMapper;

namespace Assignment.Blog.Services
{
	public class CommentService : ICommentService
	{
		private readonly IApplicationDbContext applicationDbContext;
		public CommentService(IApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public CommentDto GetComment(Guid? id)
		{
			var comment = applicationDbContext.Comments.FirstOrDefault(c => c.Id == id);

			if (comment == null)
			{
				// TODO: throw appropirate exception later
				throw new Exception();
			}

			var commentDto = Mapper.Map<Comment, CommentDto>(comment);

			return commentDto;
		}

		public IEnumerable<CommentDto> GetCommentsByPostId(Guid postId)
		{
			var post = applicationDbContext.Posts.Any(p => p.Id == postId);
			var comments = applicationDbContext.Comments.Where(c => c.PostId == postId).ToList();

			if (!post)
			{
				// TODO: throw appropirate exception later
				throw new Exception(string.Format("Post Id {0} is not found.", postId));
			}

			var commentDtos = Mapper.Instance.MapEnumerable<Comment, CommentDto>(comments);

			return commentDtos;
		}

		public Guid? CreateComment(CommentDto commentDto)
		{
			var comment = Mapper.Map<CommentDto, Comment>(commentDto);

			applicationDbContext.Comments.Add(comment);

			applicationDbContext.SaveChanges();

			return comment.Id;
		}

		public void DeleteComment(Guid id)
		{
			var comment = applicationDbContext.Comments.FirstOrDefault(p => p.Id == id);
			if (comment == null)
			{
				// TODO: throw appropirate exception later
				throw new Exception(string.Format("Comment Id {0} is not found.", id));
			}
			applicationDbContext.Comments.Remove(comment);

			applicationDbContext.SaveChanges();
		}

		public CommentDto UpdateComment(CommentDto commentDto)
		{
			var commentToUpdate = GetComment(commentDto.Id);

			commentToUpdate.Content = commentDto.Content;

			applicationDbContext.SaveChanges();

			return commentToUpdate;
		}
	}
}
