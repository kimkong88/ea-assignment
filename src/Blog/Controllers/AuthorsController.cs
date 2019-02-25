using System;
using System.Collections.Generic;
using Assignment.Blog.Dto;
using Assignment.Blog.Services;
using Assignment.Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Blog.Controllers
{
	[Route(ApiVersion.Path + "blog/[controller]")]
	public class AuthorsController : Controller
	{
		private readonly IAuthorService authorService;

		public AuthorsController(IAuthorService authorService)
		{
			this.authorService = authorService;
		}

		/// <summary>Returns a list of all authors.</summary>
		[HttpGet]
		[Produces("application/json")]
		public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
		{
			var authors = authorService.GetAuthors();

			return Json(authors);
		}

		/// <summary>Returns an author object.</summary>
		/// <param name="authorName">An author name.</param>
		[HttpGet("{authorName}")]
		[Produces("application/json")]
		public ActionResult<AuthorDto> GetAuthorByName(string authorName)
		{
			var authorDto = authorService.GetAuthorByName(authorName);

			// Otherwise MVC will automatically return NotFound And I needed to override that.
			if (authorDto == null)
			{
				return Ok(null);
			}

			return Ok(authorDto);
		}

		/// <summary>Creates an author and returns its ID.</summary>
		/// <param name="authorDto">A author object.</param>
		[HttpPost]
		public ActionResult<Guid> CreateAuthor([FromBody] AuthorDto authorDto)
		{
			var createdAuthorId = authorService.CreateAuthor(authorDto);

			return Created(string.Empty, createdAuthorId);
		}
	}
}
