using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.Blog.Dto;
using Assignment.Common.Helpers;
using Assignment.Data;
using Assignment.Data.Entities.Blog;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Blog.Services
{
	public class PostService : IPostService
	{
		private readonly IApplicationDbContext applicationDbContext;
		public PostService(IApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public IEnumerable<PostDto> GetPosts()
		{
			var query = applicationDbContext.Posts.AsQueryable();

			query = query
				.Include(p => p.Author)
				.Include(p => p.Comments);

			var posts = query.ToList();

			var postDtos = Mapper.Instance.MapEnumerable<Post, PostDto>(posts);

			return postDtos;
		}

		public PostDto GetPost(Guid id)
		{
			var post = applicationDbContext.Posts.FirstOrDefault(p => p.Id == id);

			if (post == null)
			{
				// TODO: throw appropirate exception later
				throw new Exception();
			}

			var postDto = Mapper.Map<Post, PostDto>(post);

			return postDto;
		}

		public Guid? CreatePost(PostDto postDto)
		{
			var post = Mapper.Map<PostDto, Post>(postDto);

			applicationDbContext.Posts.Add(post);

			applicationDbContext.SaveChanges();

			return post.Id;
		}

		public void DeletePost(Guid id)
		{
			var post = applicationDbContext.Posts.FirstOrDefault(p => p.Id == id);
			if (post == null)
			{
				// TODO: throw appropirate exception later
				throw new Exception();
			}
			applicationDbContext.Posts.Remove(post);

			applicationDbContext.SaveChanges();
		}

		public PostDto UpdatePost(PostDto postDto)
		{
			var postToUpdate = GetPost(postDto.Id.Value);

			postToUpdate.Title = postDto.Title;
			postToUpdate.Content = postDto.Content;

			applicationDbContext.SaveChanges();

			return postToUpdate;
		}
	}
}
