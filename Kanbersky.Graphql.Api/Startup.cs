using GraphQL;
using GraphQL.Types;
using Kanbersky.Graphql.Business.GraphHelpers;
using Kanbersky.Graphql.Business.GraphTypes;
using Kanbersky.Graphql.Data.Concrete.EntityFramework.GenericRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Kanbersky.Graphql.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<EasyStoreQuery>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<CategoryType>();
            services.AddTransient<ProductType>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new EasyStoreSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<EasyStoreQuery>() });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Kanbersky.GraphQL Microservice",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kanbersky GraphQL");
            });
        }
    }
}
