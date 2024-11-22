using Guardian_API.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Guardian_API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly ClimaPredictionService _climaService;

        public ClimaController()
        {
            _climaService = new ClimaPredictionService();
        }

        [HttpPost("prever")]
        [SwaggerOperation(Summary = "Previsão climatica", Description = "Este endpoint faz a previsão do clima a partir dos parametros abaixo")]
        public IActionResult PreverClima([FromBody] ClimaData dados)
        {
            var precipitacao = _climaService.PreverPrecipitacao(
                dados.Temperatura,
                dados.Umidade,
                dados.VelocidadeVento);

            return Ok(new { Precipitacao = precipitacao });
        }
    }
}
