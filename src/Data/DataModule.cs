using System.Reflection;
using Autofac;

namespace Assignment.Data
{
	public class DataModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			var thisAssembly = GetType().GetTypeInfo().Assembly;
			builder.RegisterAssemblyTypes(thisAssembly)
				//Do NOT re-register the DbContext.  It was setup in the startup projects with the correct scope.
				.Except<ApplicationDbContext>()
				.AsImplementedInterfaces();
		}
	}
}
