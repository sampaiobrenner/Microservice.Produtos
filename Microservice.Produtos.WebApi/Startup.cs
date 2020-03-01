using FluentValidation.AspNetCore;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microservice.Produtos.Repositories;
using Microservice.Produtos.Repositories.Contexts;
using Microservice.Produtos.Services;
using Microservice.Produtos.Services.Validators;
using Microservice.Produtos.WebApi.GraphQL.GraphQLSchema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservice.Produtos.WebApi
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphQL<ProdutoSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProdutoModelValidator>());

            IocServices.Register(services);
            IocRepositories.Register(services);

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ProdutoSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped);

            MigrateDatabase(services);
        }

        private void MigrateDatabase(IServiceCollection services)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();
        }
    }
}