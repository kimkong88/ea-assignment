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
	public class PostsControllerTest
	{
		[Fact]
		public void GetPosts_ReturnsAllPosts_ReturnsOkResponse()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IPostService>().Setup(x => x.GetPosts()).Returns(new List<PostDto>());
				var controller = mock.Create<PostsController>();

				var result = controller.GetPosts();

				Assert.IsType<JsonResult>(result.Result);
			}
		}

		[Fact]
		public void GetPost_ReturnsPost_ReturnsOkResponse()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IPostService>().Setup(x => x.GetPost(It.IsAny<Guid>())).Returns(new PostDto());
				var controller = mock.Create<PostsController>();

				var result = controller.GetPost(Guid.NewGuid());

				Assert.IsType<OkObjectResult>(result.Result);
			}
		}

		[Fact]
		public void GetPost_ExceptionThrown_ReturnsNotFound()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IPostService>().Setup(x => x.GetPost(It.IsAny<Guid>())).Throws(new Exception());
				var controller = mock.Create<PostsController>();

				var result = controller.GetPost(Guid.NewGuid());

				Assert.IsType<NotFoundObjectResult>(result.Result);
			}
		}

		[Fact]
		public void CreatePost_WithPostDto_ReturnsCreatedResponse()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IPostService>().Setup(x => x.CreatePost(It.IsAny<PostDto>())).Returns(Guid.NewGuid());
				var controller = mock.Create<PostsController>();

				var result = controller.CreatePost(new PostDto());

				Assert.IsType<CreatedResult>(result.Result);
			}
		}

		[Fact]
		public void UpdatePost_WithPostDto_ReturnsOkObjectResponse()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IPostService>().Setup(x => x.UpdatePost(It.IsAny<PostDto>())).Returns(new PostDto());
				var controller = mock.Create<PostsController>();

				var result = controller.UpdatePost(new PostDto());

				Assert.IsType<OkObjectResult>(result.Result);
			}
		}

		[Fact]
		public void DeletePost_WithId_ReturnsNoContent()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IPostService>().Setup(x => x.DeletePost(It.IsAny<Guid>()));
				var controller = mock.Create<PostsController>();

				var result = controller.DeletePost(Guid.NewGuid());

				Assert.IsType<NoContentResult>(result);
			}
		}

		[Fact]
		public void DeletePost_ExceptionThrown_ReturnsNotFound()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IPostService>().Setup(x => x.DeletePost(It.IsAny<Guid>())).Throws(new Exception());
				var controller = mock.Create<PostsController>();

				var result = controller.DeletePost(Guid.NewGuid());

				Assert.IsType<NotFoundObjectResult>(result);
			}
		}
	}
}
