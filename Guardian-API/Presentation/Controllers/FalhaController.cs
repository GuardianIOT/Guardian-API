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
    public class FalhaController : ControllerBase
    {
        private readonly IFalhaApplicationService _applicationService;

        public FalhaController(IFalhaApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as falhas", Description = "Este endpoint faz uma lista de todas as falhas criadas")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult Get()
        {
            try
            {
                var falhas = _applicationService.ObterFalhas();

                if (falhas == null)
                    return NoContent();

                return Ok(falhas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtem uma falha especifica", Description = "Este endpoint busca uma falha especifica pelo seu id")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var falha = _applicationService.ObterFalhaPorId(id);

                if (falha == null)
                    return NoContent();

                return Ok(falha);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma falha", Description = "Este endpoint realiza o cadastro de uma falha")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult Post([FromBody] FalhaDto falhaDto)
        {
            try
            {
                var falha = _applicationService.AdicionarFalha(falhaDto);

                return Ok(falha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar uma falha", Description = "Este endpoint realiza a atualizacao de uma falha")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult Put(int id, [FromBody] FalhaDto falhaDto)
        {
            try
            {
                var falha = _applicationService.EditarFalha(id, falhaDto);

                return Ok(falha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover uma falha", Description = "Este endpoint faz a exclusão de uma falha")]
        [Produces(typeof(FalhaEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var falha = _applicationService.ExcluirFalha(id);

                return Ok(falha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
