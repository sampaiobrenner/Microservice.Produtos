using Microservice.Produtos.Entities.Entities;
using Microservice.Produtos.Repositories.Base;
using Microservice.Produtos.Repositories.Contexts;
using Microservice.Produtos.Repositories.Interfaces;

namespace Microservice.Produtos.Repositories.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoContext context) : base(context)
        {
        }
    }
}