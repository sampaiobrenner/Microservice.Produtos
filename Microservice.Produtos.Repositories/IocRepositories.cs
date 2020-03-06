using Microservice.Produtos.Repositories.Contexts;
using Microservice.Produtos.Repositories.Interfaces;
using Microservice.Produtos.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Produtos.Repositories
{
    public class IocRepositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=mssql;Database=microservice-produtos;User Id=sa;Password=Hiper@987!@!@!@;"));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}