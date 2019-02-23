using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data.Entities.Blog
{
	public class Post
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public Guid Id { get; set; }

		[ForeignKey("Author")]
		[Column("author_id")]
		public Guid AuthorId { get; set; }

		[Column("title")]
		public string Title { get; set; }

		[Column("context")]
		public string Context { get; set; }

		public Author Author { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}
