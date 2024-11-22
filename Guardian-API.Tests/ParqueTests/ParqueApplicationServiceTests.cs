using Guardian_API.Application.Dtos;
using Guardian_API.Application.Services;
using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;
using Moq;

namespace Guardian_API.Tests.ParqueTests
{
    public class ParqueApplicationServiceTests
    {
        private readonly ParqueApplicationService _service;
        private readonly Mock<IParqueRepository> _parqueRepositoryMock;

        public ParqueApplicationServiceTests()
        {
            _parqueRepositoryMock = new Mock<IParqueRepository>();
            _service = new ParqueApplicationService(_parqueRepositoryMock.Object);
        }

        [Fact]
        public void ObterParques_DeveRetornarListaDeParques()
        {
            var parques = new List<ParqueEntity>
            {
                new ParqueEntity { Id = 1, Nome = "Parque 1" },
                new ParqueEntity { Id = 2, Nome = "Parque 2" }
            };

            _parqueRepositoryMock.Setup(r => r.ObterTodos()).Returns(parques);

            var result = _service.ObterParques();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _parqueRepositoryMock.Verify(r => r.ObterTodos(), Times.Once);
        }

        [Fact]
        public void ObterParquePorId_DeveRetornarParque_QuandoIdExiste()
        {
            var parque = new ParqueEntity { Id = 1, Nome = "Parque 1" };

            _parqueRepositoryMock.Setup(r => r.ObterPorId(1)).Returns(parque);

            var result = _service.ObterParquePorId(1);

            Assert.NotNull(result);
            Assert.Equal("Parque 1", result?.Nome);
            _parqueRepositoryMock.Verify(r => r.ObterPorId(1), Times.Once);
        }

        [Fact]
        public void ObterParquePorId_DeveRetornarNull_QuandoIdNaoExiste()
        {
            _parqueRepositoryMock.Setup(r => r.ObterPorId(1)).Returns((ParqueEntity?)null);

            var result = _service.ObterParquePorId(1);

            Assert.Null(result);
            _parqueRepositoryMock.Verify(r => r.ObterPorId(1), Times.Once);
        }

        [Fact]
        public void AdicionarParque_DeveAdicionarEretornarParque()
        {
            var dto = new ParqueDto
            {
                Nome = "Parque 1",
                AnoInauguracao = DateTime.Now,
                AreaKm = 10,
                Tecnologia = "Onshore",
                StatusOperacao = "Ativo",
                NumeroAerogeradores = 5
            };

            var parque = new ParqueEntity
            {
                Id = 1,
                Nome = dto.Nome,
                AnoInauguracao = dto.AnoInauguracao,
                AreaKm = dto.AreaKm,
                Tecnologia = dto.Tecnologia,
                StatusOperacao = dto.StatusOperacao,
                NumeroAerogeradores = dto.NumeroAerogeradores
            };

            _parqueRepositoryMock.Setup(r => r.Adicionar(It.IsAny<ParqueEntity>())).Returns(parque);

            var result = _service.AdicionarParque(dto);

            Assert.NotNull(result);
            Assert.Equal("Parque 1", result?.Nome);
            _parqueRepositoryMock.Verify(r => r.Adicionar(It.IsAny<ParqueEntity>()), Times.Once);
        }

        [Fact]
        public void EditarParque_DeveAtualizarEretornarParque()
        {
            var dto = new ParqueDto
            {
                Nome = "Parque Atualizado",
                AnoInauguracao = DateTime.Now,
                AreaKm = 15,
                Tecnologia = "Offshore",
                StatusOperacao = "Em Manutenção",
                NumeroAerogeradores = 10
            };

            var parque = new ParqueEntity
            {
                Id = 1,
                Nome = dto.Nome,
                AnoInauguracao = dto.AnoInauguracao,
                AreaKm = dto.AreaKm,
                Tecnologia = dto.Tecnologia,
                StatusOperacao = dto.StatusOperacao,
                NumeroAerogeradores = dto.NumeroAerogeradores
            };

            _parqueRepositoryMock.Setup(r => r.Editar(It.IsAny<ParqueEntity>())).Returns(parque);

            var result = _service.EditarParque(1, dto);

            Assert.NotNull(result);
            Assert.Equal("Parque Atualizado", result?.Nome);
            _parqueRepositoryMock.Verify(r => r.Editar(It.IsAny<ParqueEntity>()), Times.Once);
        }

        [Fact]
        public void ExcluirParque_DeveExcluirEretornarParque()
        {
            var parque = new ParqueEntity { Id = 1, Nome = "Parque 1" };

            _parqueRepositoryMock.Setup(r => r.Excluir(1)).Returns(parque);

            var result = _service.ExcluirParque(1);

            Assert.NotNull(result);
            Assert.Equal("Parque 1", result?.Nome);
            _parqueRepositoryMock.Verify(r => r.Excluir(1), Times.Once);
        }
    }
}
