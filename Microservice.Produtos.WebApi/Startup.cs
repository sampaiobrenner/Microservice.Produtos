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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Retry;
using System;

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

            GetRetryPolicy().Execute(() => MigrateDatabase(app));
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
        }

        public void MigrateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            if (context.AllMigrationsApplied()) return;

            context.Database.Migrate();
        }

        private static RetryPolicy GetRetryPolicy() =>
            Policy
                .Handle<Exception>()
                .WaitAndRetry(10, i => TimeSpan.FromSeconds(5));
    }
}