using Xunit;

namespace Assignment.Tests.BlogTest
{
	public class BlogSharedCollection
	{
		[CollectionDefinition("BlogSharedCollection")]
		public class Collection : ICollectionFixture<BlogSharedFixture>
		{
			// See https://xunit.github.io/docs/shared-context.html This class has no code, and is
			// never created. Its purpose is simply to be the place to apply [CollectionDefinition]
			// and all the ICollectionFixture<> interfaces.}
		}
	}
}
