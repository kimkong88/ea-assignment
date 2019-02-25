using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.Blog.Dto;
using Assignment.Blog.Services;
using Assignment.Data;
using Assignment.Data.Entities.Blog;
using Assignment.Tests.BlogTest.Helpers;
using Autofac.Extras.Moq;
using Xunit;

namespace Assignment.Tests.BlogTest.Services
{
	[Collection("BlogSharedCollection")]
	public class AuthorServiceTest
	{
		private readonly Guid authorId1 = Guid.NewGuid();
		private readonly Guid authorId2 = Guid.NewGuid();

		private IEnumerable<Author> GetAuthors()
		{
			return new List<Author>()
			{
				new Author()
				{
					Id = authorId1,
					Name = "test"
				},
				new Author()
				{
					Id = authorId2,
					Name = "test2"
				}
			};
		}

		[Fact]
		public void GetAuthors_ReturnAll_Success()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedAuthors = MockDbSetHelper.CreateDbSetMock(GetAuthors());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Authors).Returns(mockedAuthors.Object);

				var service = mock.Create<AuthorService>();

				var result = service.GetAuthors();

				Assert.Equal(2, result.Count());
			}
		}

		[Fact]
		public void GetAuthorByName_WithTest_ReturnAuthor()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedAuthors = MockDbSetHelper.CreateDbSetMock(GetAuthors());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Authors).Returns(mockedAuthors.Object);

				var service = mock.Create<AuthorService>();

				var result = service.GetAuthorByName("test");

				Assert.Equal(authorId1, result.Id);
			}
		}

		[Fact]
		public void CreateAuthor_WithAuthorObject_ReturnsGuid()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var mockedAuthors = MockDbSetHelper.CreateDbSetMock(GetAuthors());
				mock.Mock<IApplicationDbContext>().Setup(m => m.Authors).Returns(mockedAuthors.Object);

				var service = mock.Create<AuthorService>();
				var id = Guid.NewGuid();
				var authorToCreate = new AuthorDto()
				{
					Id = id
				};

				var result = service.CreateAuthor(authorToCreate);

				Assert.Equal(id, result);
			}
		}
	}
}
