using System;
using System.Collections.Generic;
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
	public class CommentServiceTest
	{
		private readonly Guid commentId1 = Guid.NewGuid();
		private readonly Guid commentId12 = Guid.NewGuid();
		private readonly Guid postId1 = Guid.NewGuid();
		private readonly Guid postId2 = Guid.NewGuid();

		private IEnumerable<Comment> GetComments()
		{
			return new List<Comment>()
			{
				new Comment()
				{
					Id = commentId1,
					Content = "test",
					PostId = postId1
				},
				new Comment()
				{
					Id = commentId1,
					Content = "test2",
					PostId = postId2
				}
			};
		}

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
		public void GetComment_WithValidId_ReturnsComment()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedComments = MockDbSetHelper.CreateDbSetMock(GetComments());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Comments).Returns(mockedComments.Object);

				var service = mock.Create<CommentService>();

				var result = service.GetComment(commentId1);

				Assert.Equal("test", result.Content);
			}
		}

		[Fact]
		public void GetComment_WithInvalidId_Throws()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedComments = MockDbSetHelper.CreateDbSetMock(GetComments());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Comments).Returns(mockedComments.Object);

				var service = mock.Create<CommentService>();

				Action act = () => service.GetComment(Guid.NewGuid());

				Assert.Throws<Exception>(act);
			}
		}

		[Fact]
		public void GetCommentByPostId_WithValidId_ReturnsComment()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedComments = MockDbSetHelper.CreateDbSetMock(GetComments());
				var mockedPosts = MockDbSetHelper.CreateDbSetMock(GetPosts());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Comments).Returns(mockedComments.Object);
				mock.Mock<IApplicationDbContext>().Setup(m => m.Posts).Returns(mockedPosts.Object);

				var service = mock.Create<CommentService>();

				var result = service.GetCommentsByPostId(postId1);

				Assert.Single(result);
			}
		}

		[Fact]
		public void CreateComment_WithCommentDto_ReturnsGuid()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedComments = MockDbSetHelper.CreateDbSetMock(GetComments());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Comments).Returns(mockedComments.Object);

				var service = mock.Create<CommentService>();
				var id = Guid.NewGuid();

				var result = service.CreateComment(new Blog.Dto.CommentDto()
				{
					Id = id
				});

				Assert.Equal(id, result);
			}
		}

		[Fact]
		public void DeleteComment_WithValidId_DeletesComment()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedComments = MockDbSetHelper.CreateDbSetMock(GetComments());
				var mockedDbContext = mock.Mock<IApplicationDbContext>();
				mockedDbContext.Setup(m => m.Comments).Returns(mockedComments.Object);

				var service = mock.Create<CommentService>();

				service.DeleteComment(commentId1);

				mockedDbContext.Verify(m => m.SaveChanges(), Times.Once);
			}
		}

		[Fact]
		public void DeleteComment_WithInvalidId_ThrowsError()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedComments = MockDbSetHelper.CreateDbSetMock(GetComments());
				var mockedDbContext = mock.Mock<IApplicationDbContext>();
				mockedDbContext.Setup(m => m.Comments).Returns(mockedComments.Object);

				var service = mock.Create<CommentService>();

				Action act = () => service.DeleteComment(Guid.NewGuid());

				Assert.Throws<Exception>(act);
			}
		}

		[Fact]
		public void UpdateComment_WithCommentDto_ReturnsCommentDto()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedComments = MockDbSetHelper.CreateDbSetMock(GetComments());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Comments).Returns(mockedComments.Object);

				var service = mock.Create<CommentService>();

				var result = service.UpdateComment(new Blog.Dto.CommentDto()
				{
					Id = commentId1,
					Content = "updated"
				});

				Assert.Equal("updated", result.Content);
			}
		}
	}
}
