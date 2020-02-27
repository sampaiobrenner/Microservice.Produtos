using Microservice.Produtos.Entities.Base;
using System;

namespace Microservice.Produtos.Entities.Entities
{
    public class Produto : EntityBase
    {
        private Produto(Guid id, string nome, decimal precoDeCusto, decimal precoDeVenda) : base(id)
        {
            SetNome(nome);
            SetPrecoDeCusto(precoDeCusto);
            SetPrecoDeVenda(precoDeVenda);
        }

        public CategoriaDoProduto CategoriaDoProduto { get; private set; }

        public string Nome { get; private set; }

        public decimal PrecoDeCusto { get; private set; }

        public decimal PrecoDeVenda { get; private set; }

        public void SetCategoriaDoProduto(CategoriaDoProduto categoriaDoProduto)
        {
            CategoriaDoProduto = categoriaDoProduto;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                AddError("O campo nome deve ser informado.");
                return;
            }

            Nome = nome;
        }

        public void SetPrecoDeCusto(decimal precoDeCusto)
        {
            if (default == precoDeCusto)
            {
                AddError("O campo preco de custo deve ser maior que zero.");
                return;
            }

            PrecoDeCusto = precoDeCusto;
        }

        public void SetPrecoDeVenda(decimal precoDeVenda)
        {
            if (default == precoDeVenda)
            {
                AddError("O campo preco de venda deve ser maior que zero.");
                return;
            }
            PrecoDeVenda = precoDeVenda;
        }

        internal static Produto CreateInstance(Guid id, string nome, decimal precoDeCusto, decimal precoDeVenda) =>
            new Produto(id, nome, precoDeCusto, precoDeVenda);
    }
}