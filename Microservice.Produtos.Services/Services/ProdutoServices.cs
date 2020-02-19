using AutoMapper;
using Microservice.Produtos.Entities.Entities;
using Microservice.Produtos.Repositories.Interfaces;
using Microservice.Produtos.Services.Base;
using Microservice.Produtos.Services.Interfaces;
using Microservice.Produtos.Services.Models;

namespace Microservice.Produtos.Services.Services
{
    public class ProdutoServices : ServiceBase<Produto, ProdutoModel>, IProdutoServices
    {
        public ProdutoServices(IRepository<Produto> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}