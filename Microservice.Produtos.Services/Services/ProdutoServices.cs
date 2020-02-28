using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microservice.Produtos.Entities.Entities.Builders;
using Microservice.Produtos.Repositories.Interfaces;
using Microservice.Produtos.Services.Interfaces;
using Microservice.Produtos.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Produtos.Services.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoServices(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
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
            var produto = new ProdutoBuilder()
                .WithId(model.Id ?? Guid.Empty)
                .WithNome(model.Nome)
                .WithPrecoDeCusto(model.PrecoDeCusto)
                .WithPrecoDeVenda(model.PrecoDeVenda)
                .Build();

            _produtoRepository.Update(produto);
            return _mapper.Map<ProdutoModel>(produto);
        }

        public async Task<ProdutoModel> EditAsync(ProdutoModel model, CancellationToken cancellationToken)
        {
            var produto = new ProdutoBuilder()
                           .WithId(model.Id ?? Guid.Empty)
                           .WithNome(model.Nome)
                           .WithPrecoDeCusto(model.PrecoDeCusto)
                           .WithPrecoDeVenda(model.PrecoDeVenda)
                           .Build();

            await _produtoRepository.UpdateAsync(produto, cancellationToken);
            return _mapper.Map<ProdutoModel>(produto);
        }

        public bool Exists(Guid id) => _produtoRepository.Exists(id);

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) =>
             await _produtoRepository.ExistsAsync(id, cancellationToken);

        public IList<ProdutoModel> GetAll() =>
            _produtoRepository.SelectAll()
                .ProjectTo<ProdutoModel>(_mapper.ConfigurationProvider)
                .ToList();

        public async Task<IList<ProdutoModel>> GetAllAsync(CancellationToken cancellationToken) =>
            await _produtoRepository.SelectAll()
                .ProjectTo<ProdutoModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        public ProdutoModel GetById(Guid id) =>
            _mapper.Map<ProdutoModel>(_produtoRepository.SelectById(id));

        public async Task<ProdutoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _mapper.Map<ProdutoModel>(await _produtoRepository.SelectByIdAsync(id, cancellationToken));

        public ProdutoModel Save(ProdutoModel model)
        {
            var produto = new ProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome(model.Nome)
                .WithPrecoDeCusto(model.PrecoDeCusto)
                .WithPrecoDeVenda(model.PrecoDeVenda)
                .Build();

            _produtoRepository.Insert(produto);

            return _mapper.Map<ProdutoModel>(produto);
        }

        public async Task<ProdutoModel> SaveAsync(ProdutoModel model, CancellationToken cancellationToken)
        {
            var produto = new ProdutoBuilder()
                         .WithId(Guid.NewGuid())
                         .WithNome(model.Nome)
                         .WithPrecoDeCusto(model.PrecoDeCusto)
                         .WithPrecoDeVenda(model.PrecoDeVenda)
                         .Build();

            await _produtoRepository.InsertAsync(produto, cancellationToken);
            return _mapper.Map<ProdutoModel>(produto);
        }
    }
}