using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Guardian_API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueController : ControllerBase
    {
        private readonly IParqueApplicationService _parqueApplicationService;

        public ParqueController(IParqueApplicationService parqueApplicationService)
        {
            _parqueApplicationService = parqueApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtem todos os parques", Description = "Este endpoint busca todos os parques eólicos")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult Get()
        {
            try
            {
                var parques = _parqueApplicationService.ObterParques();

                if (parques == null)
                    return NoContent();

                return Ok(parques);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtem um parque", Description = "Este endpoint realiza a busca de um parque eólico especifico")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var parques = _parqueApplicationService.ObterParquePorId(id);

                if (parques == null)
                    return NoContent();

                return Ok(parques);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar um parque", Description = "Este endpoint realiza o cadastro de um parque eólico")]
        [Produces(typeof(FalhaEntity))]

        public IActionResult Post([FromBody] ParqueDto parqueDto)
        {
            try
            {
                var parques = _parqueApplicationService.AdicionarParque(parqueDto);

                return Ok(parques);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar um parque", Description = "Este endpoint realiza a atualizacao de um parque eólico")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult Put(int id, [FromBody] ParqueDto parqueDto)
        {
            try
            {
                var parques = _parqueApplicationService.EditarParque(id, parqueDto);

                return Ok(parques);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover um parque", Description = "Este endpoint realiza a exclusão de um parque eólico")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var parques = _parqueApplicationService.ExcluirParque(id);

                return Ok(parques);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
