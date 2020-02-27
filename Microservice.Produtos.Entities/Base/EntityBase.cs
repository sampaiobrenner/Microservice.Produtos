using System;

namespace Microservice.Produtos.Entities.Base
{
    public abstract class EntityBase : ErrorBase
    {
        protected EntityBase(Guid id) => SetId(id);

        public virtual Guid Id { get; set; }

        public void SetId(Guid id)
        {
            if (default == id)
            {
                AddError("O campo ID deve ser informado.");
                return;
            }

            Id = id;
        }
    }
}