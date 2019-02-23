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
	public class AuthorService : IAuthorService
	{
		private readonly IApplicationDbContext applicationDbContext;

		public AuthorService(IApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public Guid? CreateAuthor(AuthorDto authorDto)
		{
			var author = Mapper.Map<AuthorDto, Author>(authorDto);

			applicationDbContext.Authors.Add(author);

			applicationDbContext.SaveChanges();

			return author.Id;
		}

		public IEnumerable<AuthorDto> GetAuthors()
		{
			var authors = applicationDbContext.Authors.AsEnumerable();

			var authorDtos = Mapper.Instance.MapEnumerable<Author, AuthorDto>(authors);

			return authorDtos;
		}
	}
}
