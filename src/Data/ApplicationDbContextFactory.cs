using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Assignment.Data
{
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		private const string projectName = "Api";

		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, projectName);

			var configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json")
				.Build();
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseNpgsql(connectionString);

			return new ApplicationDbContext(optionsBuilder.Options);
		}
	}
}
