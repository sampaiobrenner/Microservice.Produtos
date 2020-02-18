using System;

namespace Microservice.Produtos.Services.Abstractions.Base
{
    public abstract class BaseModel : BaseError
    {
        public virtual Guid? Id { get; set; }
    }
}