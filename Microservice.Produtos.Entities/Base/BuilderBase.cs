using System;

namespace Microservice.Produtos.Entities.Base
{
    public abstract class BuilderBase<TBuilder, TEntity>
        where TBuilder : BuilderBase<TBuilder, TEntity>
        where TEntity : class
    {
        public Guid Id { get; private set; }

        public abstract TEntity Build();

        public TBuilder WithId(Guid id)
        {
            Id = id;
            return (TBuilder)this;
        }
    }
}