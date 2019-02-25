using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.Blog.Services;
using Assignment.Data;
using Assignment.Data.Entities.Blog;
using Assignment.Tests.BlogTest.Helpers;
using Autofac.Extras.Moq;
using Moq;
using Xunit;

namespace Assignment.Tests.BlogTest.Services
{
	[Collection("BlogSharedCollection")]
	public class PostServiceTest
	{
		private readonly Guid postId1 = Guid.NewGuid();
		private readonly Guid postId2 = Guid.NewGuid();

		private IEnumerable<Post> GetPosts()
		{
			return new List<Post>()
			{
				new Post()
				{
					Id = postId1,
					Title = "test",
					Content = "test"
				},
				new Post()
				{
					Id = postId2,
					Title = "test2",
					Content = "test2"
				}
			};
		}

		[Fact]
		public void GetPosts_ReturnAll_ReturnsAllPosts()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<PostService>();

				var result = service.GetPosts();

				Assert.Equal(2, result.Count());
			}
		}

		[Fact]
		public void GetPost_WithPostId1_ReturnsPostDto()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<PostService>();

				var result = service.GetPost(postId1);

				Assert.Equal("test", result.Title);
			}
		}

		[Fact]
		public void GetPost_InvalidId_ThrowsError()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<PostService>();

				Action act = () => service.GetPost(Guid.NewGuid());

				Assert.Throws<Exception>(act);
			}
		}

		[Fact]
		public void CreatePost_WithPostDto_ReturnsGuid()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<PostService>();
				var id = Guid.NewGuid();

				var result = service.CreatePost(new Blog.Dto.PostDto()
				{
					Id = id
				});

				Assert.Equal(id, result);
			}
		}

		[Fact]
		public void DeletePost_WithPostId1_DeletesPost()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				var mockedDbContext = mock.Mock<IApplicationDbContext>();

				mockedDbContext.Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<PostService>();

				service.DeletePost(postId1);

				mockedDbContext.Verify(m => m.SaveChanges(), Times.Once);
			}
		}

		[Fact]
		public void DeletePost_WithInvalidId_ThrowsError()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				var mockedDbContext = mock.Mock<IApplicationDbContext>();

				mockedDbContext.Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<PostService>();

				Action act = () => service.DeletePost(Guid.NewGuid());

				Assert.Throws<Exception>(act);
			}
		}

		[Fact]
		public void UpdatePost_WithDifferentTitle_UpdatesTitle()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				var mockedDbContext = mock.Mock<IApplicationDbContext>();

				mockedDbContext.Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<PostService>();

				var result = service.UpdatePost(new Blog.Dto.PostDto()
				{
					Id = postId1,
					Title = "test123"
				});

				Assert.Equal("test123", result.Title);
			}
		}
	}
}
