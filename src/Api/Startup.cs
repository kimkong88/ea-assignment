using System;
using System.IO;
using Assignment.Blog;
using Assignment.Blog.Profiles;
using Assignment.Common;
using Assignment.Common.Constants;
using Assignment.Data;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Assignment.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Mapper.Initialize(config =>
			{
				config.AddProfile<PostProfile>();
				config.AddProfile<AuthorProfile>();
				config.AddProfile<CommentProfile>();
			});
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddOptions();

			services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddSingleton(Configuration);
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});

			ConfigureSwaggerServices(services);

			var container = CreateAutofacContainer(services);

			return new AutofacServiceProvider(container);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors("CorsPolicy");

			app.UseMvc();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint($"/swagger/{ApiVersion.Version}/swagger.json", "EA Assignment API");
			});
		}

		private static IContainer CreateAutofacContainer(IServiceCollection services)
		{
			var builder = new ContainerBuilder();
			builder.Populate(services);
			builder.RegisterModule<ApiModule>();
			builder.RegisterModule<DataModule>();
			builder.RegisterModule<BlogModule>();
			builder.RegisterModule<CommonModule>();

			var container = builder.Build();
			return container;
		}

		private void ConfigureSwaggerServices(IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(ApiVersion.Version, new Info { Title = "EA Assignment API", Version = ApiVersion.Version });
				AddAllXmlCommentsInSwagger(c);
			});
		}

		private static void AddAllXmlCommentsInSwagger(SwaggerGenOptions swaggerGenOptions)
		{
			var basePath = PlatformServices.Default.Application.ApplicationBasePath;
			foreach (var file in Directory.EnumerateFiles(basePath, "Assignment.*.xml"))
			{
				swaggerGenOptions.IncludeXmlComments(Path.Combine(basePath, file));
			}
		}
	}
}
