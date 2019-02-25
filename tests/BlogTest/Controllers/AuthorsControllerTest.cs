using System;
using System.Collections.Generic;
using Assignment.Blog.Controllers;
using Assignment.Blog.Dto;
using Assignment.Blog.Services;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Assignment.Tests.BlogTest.Controllers
{
	[Collection("BlogSharedCollection")]
	public class AuthorsControllerTest
	{
		[Fact]
		public void GetAuthors_ReturnsAllAuthors_ReturnsOkResponse()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IAuthorService>().Setup(x => x.GetAuthors()).Returns(new List<AuthorDto>());
				var controller = mock.Create<AuthorsController>();

				var result = controller.GetAuthors();

				Assert.IsType<JsonResult>(result.Result);
			}
		}

		[Fact]
		public void GetAuthorByName_ReturnsAuthor_ReturnsOkResponse()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IAuthorService>().Setup(x => x.GetAuthorByName(It.IsAny<string>())).Returns(new AuthorDto());
				var controller = mock.Create<AuthorsController>();

				var result = controller.GetAuthorByName("test");

				Assert.IsType<OkObjectResult>(result.Result);
			}
		}

		[Fact]
		public void CreateAuthor_WithAuthorDto_ReturnsOkObjectResult()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IAuthorService>().Setup(x => x.CreateAuthor(It.IsAny<AuthorDto>())).Returns(Guid.NewGuid());
				var controller = mock.Create<AuthorsController>();

				var result = controller.CreateAuthor(new AuthorDto());

				Assert.IsType<OkObjectResult>(result.Result);
			}
		}
	}
}
