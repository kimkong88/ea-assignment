using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data.Entities.Blog
{
	[Table("comment", Schema = "blog")]
	public class Comment : ITrackableEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public Guid? Id { get; set; }

		[ForeignKey("Author")]
		[Column("author_id")]
		public Guid? AuthorId { get; set; }

		[ForeignKey("Post")]
		[Column("post_id")]
		public Guid? PostId { get; set; }

		[Column("content")]
		public string Content { get; set; }

		[Column("created_at")]
		public DateTimeOffset CreatedDateTime { get; set; }

		[Column("updated_at")]
		public DateTimeOffset UpdatedDateTime { get; set; }

		public Author Author { get; set; }

		public Post Post { get; set; }
	}
}
