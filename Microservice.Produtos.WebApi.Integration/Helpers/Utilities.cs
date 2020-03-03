using System.Collections.Generic;
using Microservice.Produtos.Entities.Entities;
using Microservice.Produtos.Entities.Entities.Builders;
using Microservice.Produtos.Repositories.Contexts;

namespace Microservice.Produtos.WebApi.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static List<Produto> GetProdutosParaTestes()
        {
            var produto1 = new ProdutoBuilder()
                .WithNome("Produto teste 1")
                .Build();

            var produto2 = new ProdutoBuilder()
               .WithNome("Produto teste 2")
               .Build();

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