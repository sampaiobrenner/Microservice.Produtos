using Microservice.Produtos.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Produtos.Services.Interfaces
{
    public interface IProdutoServices
    {
        void Delete(Guid id);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        ProdutoModel Edit(ProdutoModel model);

        Task<ProdutoModel> EditAsync(ProdutoModel model, CancellationToken cancellationToken);

        bool Exists(Guid id);

        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

        IList<ProdutoModel> GetAll();

        Task<IList<ProdutoModel>> GetAllAsync(CancellationToken cancellationToken);

        ProdutoModel GetById(Guid id);

        Task<ProdutoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        ProdutoModel Save(ProdutoModel model);

        Task<ProdutoModel> SaveAsync(ProdutoModel model, CancellationToken cancellationToken);
    }
}