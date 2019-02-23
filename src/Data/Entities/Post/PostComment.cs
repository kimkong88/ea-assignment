using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data.Entities.Post
{
	public class PostComment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public Guid Id { get; set; }

		[Column("post_id")]
		public Guid PostId { get; set; }

		[Column("comment_id")]
		public Guid CommentId { get; set; }
	}
}
