using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
                var taxaJuros = 0.01;
                decimal valorFinal = valorInicial * (decimal)Math.Pow((1 + taxaJuros), meses);

                return await Task.FromResult(Math.Round(valorFinal, 2));
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