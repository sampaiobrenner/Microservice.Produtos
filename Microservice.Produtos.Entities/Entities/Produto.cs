using Microservice.Produtos.Entities.Base;

namespace Microservice.Produtos.Entities.Entities
{
    public class Produto : EntityBase
    {
        public virtual CategoriaDoProduto CategoriaDoProduto { get; set; }
        public string Nome { get; set; }
        public decimal PrecoDeCusto { get; set; }
        public decimal PrecoDeVenda { get; set; }
    }
}