using Microsoft.AspNetCore.Mvc.Testing;
using RazorPagesProject.Tests;
using System.Net.Http;
using System.Threading.Tasks;
using WideWorldImporters.API.IntegrationTests;
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
            // Arrange
            var request = new
            {
                Url = "/api/v1/produto",
                Body = new
                {
                    Nome = "Produto teste"
                }
            };

            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_SaveAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v2/produto",
                Body = new
                {
                    Nome = "Produto teste"
                }
            };

            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}