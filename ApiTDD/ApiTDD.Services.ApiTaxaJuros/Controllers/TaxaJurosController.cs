using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiTDD.Services.ApiTaxaJuros.Controllers
{
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet("taxaJuros")]
        public async Task<float> TaxaJuros()
        {
            try
            {
                float taxaJuros = 0.01F;
                return await Task.FromResult(taxaJuros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}