using System;

namespace Microservice.Produtos.Entities.Abstractions.Base
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}