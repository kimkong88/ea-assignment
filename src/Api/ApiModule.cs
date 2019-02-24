using System.Reflection;
using Autofac;

namespace Assignment.Api
{
	public class ApiModule : Autofac.Module
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
