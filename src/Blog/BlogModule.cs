using System.Reflection;
using Autofac;

namespace Assignment.Blog
{
	public class BlogModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			var thisAssembly = GetType().GetTypeInfo().Assembly;
			builder.RegisterAssemblyTypes(thisAssembly)
				.AsImplementedInterfaces();
		}
	}
}
