namespace Assignment.Data
{
	public static class DatabaseInitializer
	{
		public static void Initialize(ApplicationDbContext applicationDbContext)
		{
			//applicationDbContext.Database.EnsureDeleted();
			applicationDbContext.Database.EnsureCreated();
		}
	}
}
