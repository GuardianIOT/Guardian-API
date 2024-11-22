using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Domain.Entities;
using Guardian_API.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian_API.Tests.FalhaTests
{
    public class FalhaControllerTests
    {
        private readonly Mock<IFalhaApplicationService> _falhaApplicationServiceMock;
        private readonly FalhaController _falhaController;

        public FalhaControllerTests()
        {
            _falhaApplicationServiceMock = new Mock<IFalhaApplicationService>();
            _falhaController = new FalhaController(_falhaApplicationServiceMock.Object);
        }

        [Fact]
        public void Get_DeveRetornarOk_ComFalhas()
        {
            var falhas = new List<FalhaEntity>
            {
                new FalhaEntity { Id = 1, Descricao = "Falha 1" },
                new FalhaEntity { Id = 2, Descricao = "Falha 2" }
            };

            _falhaApplicationServiceMock.Setup(service => service.ObterFalhas()).Returns(falhas);

            var result = _falhaController.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<FalhaEntity>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public void Get_DeveRetornarNoContent_QuandoNaoHouverFalhas()
        {
            _falhaApplicationServiceMock.Setup(service => service.ObterFalhas()).Returns((IEnumerable<FalhaEntity>)null);

            var result = _falhaController.Get();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Get_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            _falhaApplicationServiceMock.Setup(service => service.ObterFalhas()).Throws(new Exception("Erro ao obter falhas"));

            var result = _falhaController.Get();

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao obter falhas", badRequestResult.Value);
        }

        [Fact]
        public void ObterPorId_DeveRetornarOk_QuandoFalhaExiste()
        {
            var falha = new FalhaEntity { Id = 1, Descricao = "Falha Teste" };
            _falhaApplicationServiceMock.Setup(service => service.ObterFalhaPorId(1)).Returns(falha);

            var result = _falhaController.ObterPorId(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<FalhaEntity>(okResult.Value);
            Assert.Equal("Falha Teste", returnValue.Descricao);
        }

        [Fact]
        public void ObterPorId_DeveRetornarNoContent_QuandoFalhaNaoExistir()
        {
            _falhaApplicationServiceMock.Setup(service => service.ObterFalhaPorId(1)).Returns((FalhaEntity)null);

            var result = _falhaController.ObterPorId(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void ObterPorId_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            _falhaApplicationServiceMock.Setup(service => service.ObterFalhaPorId(1)).Throws(new Exception("Falha ao obter falha"));

            var result = _falhaController.ObterPorId(1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Falha ao obter falha", badRequestResult.Value);
        }

        [Fact]
        public void Post_DeveRetornarOk_QuandoFalhaForCadastradaComSucesso()
        {
            var falhaDto = new FalhaDto { Descricao = "Falha Cadastrada" };
            var falhaEntity = new FalhaEntity { Id = 1, Descricao = "Falha Cadastrada" };

            _falhaApplicationServiceMock.Setup(service => service.AdicionarFalha(falhaDto)).Returns(falhaEntity);

            var result = _falhaController.Post(falhaDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<FalhaEntity>(okResult.Value);
            Assert.Equal("Falha Cadastrada", returnValue.Descricao);
        }

        [Fact]
        public void Post_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            var falhaDto = new FalhaDto { Descricao = "Falha Cadastrada" };

            _falhaApplicationServiceMock.Setup(service => service.AdicionarFalha(falhaDto)).Throws(new Exception("Erro ao cadastrar falha"));

            var result = _falhaController.Post(falhaDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao cadastrar falha", badRequestResult.Value);
        }

        [Fact]
        public void Put_DeveRetornarOk_QuandoFalhaForAtualizadaComSucesso()
        {
            var falhaDto = new FalhaDto { Descricao = "Falha Atualizada" };
            var falhaEntity = new FalhaEntity { Id = 1, Descricao = "Falha Atualizada" };

            _falhaApplicationServiceMock.Setup(service => service.EditarFalha(1, falhaDto)).Returns(falhaEntity);

            var result = _falhaController.Put(1, falhaDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<FalhaEntity>(okResult.Value);
            Assert.Equal("Falha Atualizada", returnValue.Descricao);
        }

        [Fact]
        public void Put_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            var falhaDto = new FalhaDto { Descricao = "Falha Atualizada" };

            _falhaApplicationServiceMock.Setup(service => service.EditarFalha(1, falhaDto)).Throws(new Exception("Erro ao atualizar falha"));

            var result = _falhaController.Put(1, falhaDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao atualizar falha", badRequestResult.Value);
        }

        [Fact]
        public void Delete_DeveRetornarOk_QuandoFalhaForExcluidaComSucesso()
        {
            var falhaEntity = new FalhaEntity { Id = 1, Descricao = "Falha Deletada" };

            _falhaApplicationServiceMock.Setup(service => service.ExcluirFalha(1)).Returns(falhaEntity);

            var result = _falhaController.Delete(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<FalhaEntity>(okResult.Value);
            Assert.Equal("Falha Deletada", returnValue.Descricao);
        }

        [Fact]
        public void Delete_DeveRetornarBadRequest_QuandoOcorreUmaExcecao()
        {
            _falhaApplicationServiceMock.Setup(service => service.ExcluirFalha(1)).Throws(new Exception("Erro ao excluir falha"));

            var result = _falhaController.Delete(1);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Erro ao excluir falha", badRequestResult.Value);
        }
    }
}
