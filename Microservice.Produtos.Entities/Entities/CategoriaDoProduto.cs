using Microservice.Produtos.Entities.Base;
using System;

namespace Microservice.Produtos.Entities.Entities
{
    public class CategoriaDoProduto : EntityBase
    {
        private CategoriaDoProduto(Guid id, string nome) : base(id)
        {
            SetNome(nome);
        }

        public string Nome { get; private set; }

        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                AddError("O campo nome deve ser informado.");
                return;
            }

            Nome = nome;
        }

        internal static CategoriaDoProduto CreateInstance(Guid id, string nome) => new CategoriaDoProduto(id, nome);
    }
}