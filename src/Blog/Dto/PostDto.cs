using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assignment.Blog.Dto
{
	public class PostDto
	{
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Guid? Id { get; set; }

		[JsonProperty]
		public string Title { get; set; }

		[JsonProperty]
		public string Content { get; set; }

		[JsonProperty]
		public Guid? AuthorId { get; set; }

		[JsonProperty]
		public string AuthorName { get; set; }

		[JsonProperty]
		public IList<CommentDto> Comments { get; set; }

		[JsonProperty]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty]
		public DateTimeOffset UpdatedAt { get; set; }
	}
}
