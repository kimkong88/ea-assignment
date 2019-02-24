using System;
using System.Collections.Generic;
using Assignment.Blog.Dto;

namespace Assignment.Blog.Services
{
	public interface IAuthorService
	{
		Guid? CreateAuthor(AuthorDto authorDto);

		IEnumerable<AuthorDto> GetAuthors();

		AuthorDto GetAuthorByName(string authorName);
	}
}
