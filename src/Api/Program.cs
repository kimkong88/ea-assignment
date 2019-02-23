using System;
using Assignment.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);
			InitializeDatabase(host);
			host.Run();
		}

		public static IWebHost BuildWebHost(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
		}

		private static void InitializeDatabase(IWebHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
					DatabaseInitializer.Initialize(applicationDbContext);
				}
				catch (Exception exception)
				{
					// add logging
					Console.WriteLine(exception);
				}
			}
		}
	}
}
