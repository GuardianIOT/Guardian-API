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
    public class TorreController : ControllerBase
    {
        private readonly ITorreApplicationService _torreApplicationService;

        public TorreController(ITorreApplicationService torreApplicationService)
        {
            _torreApplicationService = torreApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar todas as torres", Description = "Este endpoint realiza a busca de todas as torres cadastradas")]
        [Produces(typeof(FalhaEntity))]
        public ActionResult Get()
        {
            try
            {
                var torres = _torreApplicationService.ObterTorres();

                if (torres == null)
                    return NoContent();

                return Ok(torres);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtem uma torre", Description = "Este endpoint realiza a busca de uma torre pelo seu id")]
        [Produces(typeof(FalhaEntity))]
        public ActionResult ObterPorId(int id)
        {
            try
            {
                var torre = _torreApplicationService.ObterTorrePorId(id);

                if (torre == null)
                    return NoContent();

                return Ok(torre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adicionar torre", Description = "Este endpoint adiciona uma torre")]
        [Produces(typeof(FalhaEntity))]
        public ActionResult Post([FromBody] TorreDto torreDto)
        {
            try
            {
                var torre = _torreApplicationService.AdicionarTorre(torreDto);

                return Ok(torre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar torre", Description = "Este endpoint realiza a atualizacao de uma torre")]
        [Produces(typeof(FalhaEntity))]
        public ActionResult Put(int id, [FromBody] TorreDto torreDto)
        {
            try
            {
                var torre = _torreApplicationService.EditarTorre(id, torreDto);

                return Ok(torre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover uma torre", Description = "Este endpoint realiza a exclusão de uma torre")]
        [Produces(typeof(FalhaEntity))]
        public ActionResult Delete(int id)
        {
            try
            {
                var torre = _torreApplicationService.ExcluirTorre(id);

                return Ok(torre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
