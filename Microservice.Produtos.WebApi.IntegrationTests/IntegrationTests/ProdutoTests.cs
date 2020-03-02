using Microservice.Produtos.Services.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using RazorPagesProject.Tests;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.Produtos.WebApi.IntegrationTests.IntegrationTests
{
    public class ProdutoTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ProdutoTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Theory]
        [InlineData("/api/v1/produto")]
        [InlineData("/api/v2/produto")]
        [InlineData("/api/v3/produto")]
        public async Task Get_EndPointsRetornamSucessoEContentTypeCorreto(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Post_Save()
        {
            var produto = new ProdutoModel();
            produto.Nome = "Produto teste";

            //Act
            var response = await _client.PostAsync("/api/v1/produto", null);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Post_SaveAsync()
        {
            var produto = new ProdutoModel();
            produto.Nome = "Produto teste";

            //Act
            var response = await _client.PostAsync("/api/v2/produto", null);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}