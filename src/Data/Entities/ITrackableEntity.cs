using System;

namespace Assignment.Data.Entities
{
	public interface ITrackableEntity
	{
		DateTimeOffset CreatedDateTime { get; set; }
		DateTimeOffset UpdatedDateTime { get; set; }
	}
}
