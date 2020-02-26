using Microservice.Produtos.Entities.Base;
using System.Collections.Generic;

namespace Microservice.Produtos.Entities.Entities
{
    public class CategoriaDoProduto : EntityBase
    {
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}