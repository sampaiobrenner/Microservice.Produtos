using Microservice.Produtos.Repositories.Interfaces;
using Microservice.Produtos.Services.Interfaces;
using Microservice.Produtos.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Produtos.Services.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Delete(Guid id)
        {
            if (default == id) return;
            _produtoRepository.Delete(id);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (default == id) return;
            await _produtoRepository.DeleteAsync(id, cancellationToken);
        }

        public ProdutoModel Edit(ProdutoModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> EditAsync(ProdutoModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProdutoModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ProdutoModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ProdutoModel Save(ProdutoModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> SaveAsync(ProdutoModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}