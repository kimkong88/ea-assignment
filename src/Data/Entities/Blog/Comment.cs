using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data.Entities.Blog
{
	[Table("comment", Schema = "blog")]
	public class Comment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public Guid Id { get; set; }

		[ForeignKey("Author")]
		[Column("author_id")]
		public Guid AuthorId { get; set; }

		[Column("context")]
		public string Context { get; set; }

		public Author Author { get; set; }
	}
}
