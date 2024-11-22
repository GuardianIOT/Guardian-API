using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Domain.Entities;
using Guardian_API.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Guardian_API.Tests.TorreTests
{
    public class TorreControllerTests
    {
        private readonly Mock<ITorreApplicationService> _torreApplicationServiceMock;
        private readonly TorreController _torreController;

        public TorreControllerTests()
        {
            _torreApplicationServiceMock = new Mock<ITorreApplicationService>();
            _torreController = new TorreController(_torreApplicationServiceMock.Object);
        }

        [Fact]
        public void Get_DeveRetornarOk_ComTorres()
        {
            var torres = new List<TorreEntity>
            {
                new TorreEntity { Id = 1, Nome = "Torre 1" },
                new TorreEntity { Id = 2, Nome = "Torre 2" }
            };

            _torreApplicationServiceMock.Setup(service => service.ObterTorres()).Returns(torres);

            var result = _torreController.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<TorreEntity>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public void Get_DeveRetornarNoContent_QuandoNaoHouverTorres()
        {
            _torreApplicationServiceMock.Setup(service => service.ObterTorres()).Returns((IEnumerable<TorreEntity>)null);

            var result = _torreController.Get();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Get_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            _torreApplicationServiceMock.Setup(service => service.ObterTorres()).Throws(new Exception("Erro ao obter torres"));

            var result = _torreController.Get();

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao obter torres", badRequestResult.Value);
        }

        [Fact]
        public void ObterPorId_DeveRetornarOk_QuandoTorreExiste()
        {
            var torre = new TorreEntity { Id = 1, Nome = "Torre Teste" };
            _torreApplicationServiceMock.Setup(service => service.ObterTorrePorId(1)).Returns(torre);

            var result = _torreController.ObterPorId(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<TorreEntity>(okResult.Value);
            Assert.Equal("Torre Teste", returnValue.Nome);
        }

        [Fact]
        public void ObterPorId_DeveRetornarNoContent_QuandoTorreNaoExistir()
        {
            _torreApplicationServiceMock.Setup(service => service.ObterTorrePorId(1)).Returns((TorreEntity)null);

            var result = _torreController.ObterPorId(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void ObterPorId_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            _torreApplicationServiceMock.Setup(service => service.ObterTorrePorId(1)).Throws(new Exception("Erro ao obter torre"));

            var result = _torreController.ObterPorId(1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao obter torre", badRequestResult.Value);
        }

        [Fact]
        public void Post_DeveRetornarOk_QuandoTorreForCadastradaComSucesso()
        {
            var torreDto = new TorreDto { Nome = "Torre Cadastrada" };
            var torreEntity = new TorreEntity { Id = 1, Nome = "Torre Cadastrada" };

            _torreApplicationServiceMock.Setup(service => service.AdicionarTorre(torreDto)).Returns(torreEntity);

            var result = _torreController.Post(torreDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<TorreEntity>(okResult.Value);
            Assert.Equal("Torre Cadastrada", returnValue.Nome);
        }

        [Fact]
        public void Post_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            var torreDto = new TorreDto { Nome = "Torre Cadastrada" };

            _torreApplicationServiceMock.Setup(service => service.AdicionarTorre(torreDto)).Throws(new Exception("Erro ao cadastrar torre"));

            var result = _torreController.Post(torreDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao cadastrar torre", badRequestResult.Value);
        }

        [Fact]
        public void Put_DeveRetornarOk_QuandoTorreForAtualizadaComSucesso()
        {
            var torreDto = new TorreDto { Nome = "Torre Atualizada" };
            var torreEntity = new TorreEntity { Id = 1, Nome = "Torre Atualizada" };

            _torreApplicationServiceMock.Setup(service => service.EditarTorre(1, torreDto)).Returns(torreEntity);

            var result = _torreController.Put(1, torreDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<TorreEntity>(okResult.Value);
            Assert.Equal("Torre Atualizada", returnValue.Nome);
        }

        [Fact]
        public void Put_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            var torreDto = new TorreDto { Nome = "Torre Atualizada" };

            _torreApplicationServiceMock.Setup(service => service.EditarTorre(1, torreDto)).Throws(new Exception("Erro ao atualizar torre"));

            var result = _torreController.Put(1, torreDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao atualizar torre", badRequestResult.Value);
        }

        [Fact]
        public void Delete_DeveRetornarOk_QuandoTorreForExcluidaComSucesso()
        {
            var torreEntity = new TorreEntity { Id = 1, Nome = "Torre Deletada" };

            _torreApplicationServiceMock.Setup(service => service.ExcluirTorre(1)).Returns(torreEntity);

            var result = _torreController.Delete(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<TorreEntity>(okResult.Value);
            Assert.Equal("Torre Deletada", returnValue.Nome);
        }

        [Fact]
        public void Delete_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            _torreApplicationServiceMock.Setup(service => service.ExcluirTorre(1)).Throws(new Exception("Erro ao excluir torre"));

            var result = _torreController.Delete(1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao excluir torre", badRequestResult.Value);
        }
    }
}
