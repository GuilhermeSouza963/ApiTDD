using ApiTDD.Services.ApiCalculaJuros;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ApiTDD.Tests.ApiCalculaJurosTest
{
    public class CalculaJurosTests
    {
        private readonly HttpClient _client;

        public CalculaJurosTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                );

            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("Get", 100, 5)]
        public async Task CalculaJurosTestAsync(string method, decimal valorInicial, int meses)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/calculaJuros?valorinicial={valorInicial}&meses={meses}");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
