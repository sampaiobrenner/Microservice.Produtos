using Microservice.Produtos.Entities.Abstractions.Base;

namespace Microservice.Produtos.Entities.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
    }
}