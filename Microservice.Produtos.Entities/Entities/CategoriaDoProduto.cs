using Microservice.Produtos.Entities.Base;
using System;
using System.Collections.Generic;

namespace Microservice.Produtos.Entities.Entities
{
    public class CategoriaDoProduto : EntityBase
    {
        protected CategoriaDoProduto(Guid id) : base(id)
        {
        }

        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}