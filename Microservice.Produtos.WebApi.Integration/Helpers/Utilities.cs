using Microservice.Produtos.Entities.Entities;
using Microservice.Produtos.Entities.Entities.Builders;
using Microservice.Produtos.Repositories.Contexts;
using System;
using System.Collections.Generic;

namespace Microservice.Produtos.WebApi.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static List<Produto> GetProdutosParaTestes()
        {
            var produto1 = new ProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome("Produto teste 1")
                .Build();

            var produto2 = new ProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome("Produto teste 2")
                .Build();

            var categoria = new CategoriaDoProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome("Categoria teste")
                .Build();

            produto2.SetCategoriaDoProduto(categoria);

            return new List<Produto>() { produto1, produto2 };
        }

        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Produtos.AddRange(GetProdutosParaTestes());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Produtos.RemoveRange(db.Produtos);
            InitializeDbForTests(db);
        }
    }
}