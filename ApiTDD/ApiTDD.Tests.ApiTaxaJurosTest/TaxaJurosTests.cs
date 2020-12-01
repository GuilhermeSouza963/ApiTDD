using ApiTDD.Services.ApiTaxaJuros;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ApiTDD.Tests.ApiTaxaJurosTest
{
    public class TaxaJurosTests
    {
        private readonly HttpClient _client;

        public TaxaJurosTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                );

            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("Get")]
        public async Task TaxaJurosTestAsync(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/taxaJuros");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            string conteudo = response.Content.ReadAsStringAsync().Result;
            var taxaJuros = JsonConvert.DeserializeObject<double>(conteudo);

            Assert.Equal(0.01, taxaJuros);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
