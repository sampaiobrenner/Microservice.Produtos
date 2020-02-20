using Microservice.Produtos.Services.Base;

namespace Microservice.Produtos.Services.Models
{
    public class ProdutoModel : ModelBase
    {
        public CategoriaDoProdutoModel CategoriaDoProduto { get; set; }
        public string Nome { get; set; }
        public decimal PrecoDeCusto { get; set; }
        public decimal PrecoDeVenda { get; set; }
    }
}