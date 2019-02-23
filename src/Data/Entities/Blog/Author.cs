using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data.Entities.Blog
{
	[Table("author", Schema = "blog")]
	public class Author : ITrackableEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public Guid? Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("created_at")]
		public DateTimeOffset CreatedDateTime { get; set; }

		[Column("updated_at")]
		public DateTimeOffset UpdatedDateTime { get; set; }
	}
}
