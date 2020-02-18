﻿using Microservice.Produtos.Entities.Abstractions.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Produtos.Repositories.Abstractions.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        void Delete(Guid id);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        bool Exists(Guid id);

        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

        void Insert(TEntity entity);

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        IQueryable<TEntity> SelectAll();

        TEntity SelectById(Guid id);

        Task<TEntity> SelectByIdAsync(Guid id, CancellationToken cancellationToken);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity, CancellationToken cancelletionToken);
    }
}