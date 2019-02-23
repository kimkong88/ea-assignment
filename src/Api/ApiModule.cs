using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;

namespace Assignment.Api
{
	public class ApiModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			RegisterAutofacModules(builder);
			var thisAssembly = GetType().GetTypeInfo().Assembly;
			builder.RegisterAssemblyTypes(thisAssembly)
			   .AsImplementedInterfaces();
		}

		private static void RegisterAutofacModules(ContainerBuilder builder)
		{
			var currentExecutingAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var currentExecutingAssemblyName = Assembly.GetExecutingAssembly().Location;
			var type = typeof(Autofac.Module);

			foreach (var dll in Directory.EnumerateFiles(currentExecutingAssemblyPath, "Assignment.*.dll"))
			{
				if (!dll.Equals(currentExecutingAssemblyName, StringComparison.InvariantCultureIgnoreCase))
				{
					var assembly = Assembly.LoadFrom(dll);
					var typeItem = assembly.GetTypes().FirstOrDefault(t => type.IsAssignableFrom(t));
					if (typeItem != null)
					{
						builder.RegisterModule((Autofac.Module)assembly.CreateInstance(typeItem.FullName));
					}
				}
			}
		}
	}
}
