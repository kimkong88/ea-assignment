using System.Reflection;
using Autofac;

namespace Assignment.Common
{
	public class CommonModule : Autofac.Module
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
