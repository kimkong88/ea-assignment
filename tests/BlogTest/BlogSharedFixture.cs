using Assignment.Blog.Profiles;
using AutoMapper;

namespace Assignment.Tests.BlogTest
{
	public class BlogSharedFixture
	{
		public BlogSharedFixture()
		{
			Mapper.Initialize(config =>
			{
				config.AddProfile<PostProfile>();
				config.AddProfile<AuthorProfile>();
				config.AddProfile<CommentProfile>();
			});
		}
	}
}
