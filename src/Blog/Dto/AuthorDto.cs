using System;
using Newtonsoft.Json;

namespace Assignment.Blog.Dto
{
	public class AuthorDto
	{
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Guid? Id { get; set; }

		[JsonProperty]
		public string Name { get; set; }
	}
}
