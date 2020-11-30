using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiTDD.Services.ApiCalculaJuros.Controllers
{
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet("calculaJuros")]
        public async Task<decimal> CalculaJuros(decimal valorInicial, int meses)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("http://localhost:54937/taxajuros").Result;

                    response.EnsureSuccessStatusCode();

                    string conteudo = response.Content.ReadAsStringAsync().Result;

                    var taxaJuros = JsonConvert.DeserializeObject<double>(conteudo);

                    decimal valorFinal = valorInicial * (decimal)Math.Pow((1 + taxaJuros), meses);

                    return await Task.FromResult(Math.Round(valorFinal, 2));
                }
           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("showMeTheCode")]
        public async Task<string> ShowMeTheCode()
        {
            try
            {
                return await Task.FromResult("https://github.com/GuilhermeSouza963/ApiTDD");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}