using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Application.Services;
using Guardian_API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Guardian_API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerogeradorController : ControllerBase
    {
        private readonly IAerogeradorApplicationService _aerogeradorApplicationService;

        public AerogeradorController(IAerogeradorApplicationService aerogeradorApplicationService)
        {
            _aerogeradorApplicationService = aerogeradorApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os Aerogeradores", Description = "Este endpoint retorna uma lista completa com todos os aerogeradores criados")]
        [Produces(typeof(IEnumerable<AerogeradorEntity>))]
        public IActionResult Get()
        {
            try
            {
                var aerogeradores = _aerogeradorApplicationService.ObterAerogeradores();

                if(aerogeradores == null)
                    return NoContent();

                return Ok(aerogeradores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Lista um aerogerador", Description = "Este endpoint retorna o aerogerador pelo id solicitado")]
        [Produces(typeof(AerogeradorEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var aerogerador = _aerogeradorApplicationService.ObterAerogeradorPorId(id);

                if(aerogerador == null)
                    return NoContent();

                return Ok(aerogerador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um aerogerador", Description = "Este endpoint cria um aerogerador")]
        [Produces(typeof(AerogeradorDto))]
        public IActionResult Post([FromBody] AerogeradorDto aerogeradorDto)
        {
            try
            {
                var aerogerador = _aerogeradorApplicationService.AdicionarAerogerador(aerogeradorDto);

                return Ok(aerogerador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Editar um aerogerador", Description = "Este endpoint edita os dados de um aerogerador")]
        [Produces(typeof(AerogeradorDto))]
        public IActionResult Put(int id, [FromBody] AerogeradorDto aerogeradorDto)
        {
            try
            {
                var aerogerador = _aerogeradorApplicationService.EditarAerogerador(id, aerogeradorDto);

                return Ok(aerogerador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um aerogerador", Description = "Este endpoint remove um aerogerador buscado pelo seu id")]
        [Produces(typeof(AerogeradorDto))]
        public IActionResult Delete(int id)
        {
            try
            { 
                var aerogerador = _aerogeradorApplicationService.ExcluirAerogerador(id);

                return Ok(aerogerador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
