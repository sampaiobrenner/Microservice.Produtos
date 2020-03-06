using Microservice.Produtos.WebApi.IntegrationTests.Helpers;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.Produtos.WebApi.IntegrationTests.IntegrationTests
{
    public class ProdutoTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ProdutoTests(CustomWebApplicationFactory<Startup> factory) => _factory = factory;

        [Theory]
        [InlineData("/api/v1/produto")]
        [InlineData("/api/v2/produto")]
        public async Task Get_EndPointsRetornamSucesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_Save()
        {
            // Arrange
            var client = _factory.CreateClient();

            var request = new
            {
                Url = "/api/v1/produto",
                Body = new
                {
                    Nome = "Teste 2",
                    PrecoDeCusto = 12,
                    PrecoDeVenda = 15
                }
            };

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_SaveAsync()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new
            {
                Url = "/api/v2/produto",
                Body = new
                {
                    Nome = "Teste 1",
                    PrecoDeCusto = 12,
                    PrecoDeVenda = 15
                }
            };

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_SaveComErro()
        {
            // Arrange
            var client = _factory.CreateClient();

            var request = new
            {
                Url = "/api/v1/produto",
                Body = new
                {
                    Nome = ""
                }
            };

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}