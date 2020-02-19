using Microservice.Produtos.Entities.Entities;
using Microservice.Produtos.Services.Models;

namespace Microservice.Produtos.Services.Interfaces
{
    public interface IProdutoServices : IService<Produto, ProdutoModel>
    {
    }
}