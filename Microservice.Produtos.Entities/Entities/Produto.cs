using Microservice.Produtos.Entities.Base;
using System;

namespace Microservice.Produtos.Entities.Entities
{
    public class Produto : EntityBase
    {
        internal Produto(Guid id, string nome, decimal precoDeCusto, decimal precoDeVenda) : base(id)
        {
            SetNome(nome);
            SetPrecoDeCusto(precoDeCusto);
            SetPrecoDeVenda(precoDeVenda);
        }

        public virtual CategoriaDoProduto CategoriaDoProduto { get; set; }
        public int? CategoriaDoProdutoId { get; set; }
        public string Nome { get; private set; }
        public decimal PrecoDeCusto { get; private set; }
        public decimal PrecoDeVenda { get; private set; }

        private void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                AddError("O campo nome deve ser informado.");
                return;
            }

            Nome = nome;
        }

        private void SetPrecoDeCusto(decimal precoDeCusto)
        {
            if (default == precoDeCusto)
            {
                AddError("O campo preco de custo deve ser maior que zero.");
                return;
            }

            PrecoDeCusto = precoDeCusto;
        }

        private void SetPrecoDeVenda(decimal precoDeVenda)
        {
            if (default == precoDeVenda)
            {
                AddError("O campo preco de venda deve ser maior que zero.");
                return;
            }
            PrecoDeVenda = precoDeVenda;
        }
    }
}