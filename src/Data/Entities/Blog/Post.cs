using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data.Entities.Blog
{
	[Table("post", Schema = "blog")]
	public class Post : ITrackableEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public Guid? Id { get; set; }

		[ForeignKey("Author")]
		[Column("author_id")]
		public Guid? AuthorId { get; set; }

		[Column("title")]
		public string Title { get; set; }

		[Column("content")]
		public string Content { get; set; }

		[Column("created_at")]
		public DateTimeOffset CreatedDateTime { get; set; }

		[Column("updated_at")]
		public DateTimeOffset UpdatedDateTime { get; set; }

		public Author Author { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}
