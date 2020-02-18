using Microservice.Produtos.Services.Abstractions.Interfaces;
using Microservice.Produtos.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Produtos.Services
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IProdutoServices, ProdutoServices>();
        }
    }
}