using System;

namespace Microservice.Produtos.Services.Base
{
    public abstract class ModelBase : ErrorBase
    {
        public virtual Guid? Id { get; set; }
    }
}