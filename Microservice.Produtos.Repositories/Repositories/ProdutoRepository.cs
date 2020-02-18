using Microservice.Produtos.Entities.Entities;
using Microservice.Produtos.Repositories.Abstractions.Base;
using Microservice.Produtos.Repositories.Abstractions.Interfaces;
using Microservice.Produtos.Repositories.Contexts;

namespace Microservice.Produtos.Repositories.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoContext context) : base(context)
        {
        }
    }
}