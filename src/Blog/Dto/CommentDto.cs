using System;
using Newtonsoft.Json;

namespace Assignment.Blog.Dto
{
	public class CommentDto
	{
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Guid? Id { get; set; }

		[JsonProperty]
		public string Content { get; set; }

		[JsonProperty]
		public Guid? AuthorId { get; set; }

		[JsonProperty]
		public Guid? PostId { get; set; }
	}
}
