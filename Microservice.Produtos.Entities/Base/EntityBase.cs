using System;

namespace Microservice.Produtos.Entities.Base
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; }
    }
}