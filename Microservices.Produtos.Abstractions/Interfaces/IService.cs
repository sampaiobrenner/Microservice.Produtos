using Microservice.Produtos.Entities.Abstractions.Base;
using Microservice.Produtos.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Produtos.Services.Abstractions.Interfaces
{
    public interface IService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        void Delete(Guid id);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        TModel Edit(TModel model);

        Task<TModel> EditAsync(TModel model, CancellationToken cancellationToken);

        bool Exists(Guid id);

        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

        IList<TModel> GetAll();

        Task<IList<TModel>> GetAllAsync(CancellationToken cancellationToken);

        TModel GetById(Guid id);

        Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        TModel Save(TModel model);

        Task<TModel> SaveAsync(TModel model, CancellationToken cancellationToken);
    }
}