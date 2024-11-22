using Guardian_API.Application.Dtos;
using Guardian_API.Application.Services;
using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian_API.Tests.AerogeradorTests
{
    public class AerogeradorApplicationServiceTests
    {
        private Mock<IAerogeradorRepository> _aerogeradorRepositoryMock;
        private AerogeradorApplicationService _aerogeradorApplicationService;

        public AerogeradorApplicationServiceTests()
        {
            _aerogeradorRepositoryMock = new Mock<IAerogeradorRepository>();
            _aerogeradorApplicationService = new AerogeradorApplicationService(_aerogeradorRepositoryMock.Object);
        }

        [Fact]
        public void ObterAerogeradores_DeveRetornarTodosOsAerogeradores()
        {
            // Arrange
            var aerogeradores = new List<AerogeradorEntity>
            {
                new AerogeradorEntity { Modelo = "Modelo 1", Tecnologia = "Onshore" },
                new AerogeradorEntity { Modelo = "Modelo 2", Tecnologia = "Offshore" }
            };

            _aerogeradorRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(aerogeradores);

            // Act
            var result = _aerogeradorApplicationService.ObterAerogeradores();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result?.Count());
        }

        [Fact]
        public void ObterAerogeradorPorId_DeveRetornarAerogeradorCorreto_QuandoIdExiste()
        {
            // Arrange
            var aerogerador = new AerogeradorEntity { Id = 1, Modelo = "Modelo Teste", Tecnologia = "Onshore" };

            _aerogeradorRepositoryMock.Setup(repo => repo.ObterPorId(1)).Returns(aerogerador);

            // Act
            var result = _aerogeradorApplicationService.ObterAerogeradorPorId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Modelo Teste", result?.Modelo);
        }

        [Fact]
        public void AdicionarAerogerador_DeveAdicionarAerogeradorCorretamente()
        {
            // Arrange
            var aerogeradorDto = new AerogeradorDto
            {
                Modelo = "Modelo Adicionado",
                Tecnologia = "Onshore",
                CapacidadeMW = 2.5,
                AlturaMastro = 100,
                VelocidadeCorte = 12,
                StatusOperacao = "Ativo",
                DiametroMotor = 120,
                DataInstalacao = DateTime.Now,
                Garantia = DateTime.Now,
            };

            var aerogeradorEntity = new AerogeradorEntity
            {
                Modelo = aerogeradorDto.Modelo,
                Tecnologia = aerogeradorDto.Tecnologia,
                CapacidadeMW = aerogeradorDto.CapacidadeMW,
                AlturaMastro = aerogeradorDto.AlturaMastro,
                VelocidadeCorte = aerogeradorDto.VelocidadeCorte,
                StatusOperacao = aerogeradorDto.StatusOperacao,
                DiametroMotor = aerogeradorDto.DiametroMotor,
                DataInstalacao = aerogeradorDto.DataInstalacao,
                Garantia = aerogeradorDto.Garantia
            };

            _aerogeradorRepositoryMock.Setup(repo => repo.Adicionar(It.IsAny<AerogeradorEntity>())).Returns(aerogeradorEntity);

            // Act
            var result = _aerogeradorApplicationService.AdicionarAerogerador(aerogeradorDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(aerogeradorDto.Modelo, result?.Modelo);
            _aerogeradorRepositoryMock.Verify(repo => repo.Adicionar(It.IsAny<AerogeradorEntity>()), Times.Once);
        }

        [Fact]
        public void EditarAerogerador_DeveEditarAerogeradorCorretamente()
        {
            // Arrange
            var aerogeradorDto = new AerogeradorDto
            {
                Modelo = "Modelo Editado",
                Tecnologia = "Offshore",
                CapacidadeMW = 3.0,
                AlturaMastro = 110,
                VelocidadeCorte = 14,
                StatusOperacao = "Inativo",
                DiametroMotor = 130,
                DataInstalacao = DateTime.Now,
                Garantia = DateTime.Now,
            };

            var aerogeradorEntity = new AerogeradorEntity
            {
                Id = 1,
                Modelo = "Modelo Original",
                Tecnologia = "Onshore",
                CapacidadeMW = 2.5,
                AlturaMastro = 100,
                VelocidadeCorte = 12,
                StatusOperacao = "Ativo",
                DiametroMotor = 120,
                DataInstalacao = DateTime.Now,
                Garantia = DateTime.Now
            };

            _aerogeradorRepositoryMock.Setup(repo => repo.ObterPorId(1)).Returns(aerogeradorEntity);
            _aerogeradorRepositoryMock.Setup(repo => repo.Editar(It.IsAny<AerogeradorEntity>())).Returns((AerogeradorEntity arg) => arg);

            // Act
            var result = _aerogeradorApplicationService.EditarAerogerador(1, aerogeradorDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(aerogeradorDto.Modelo, result?.Modelo);
            Assert.Equal(aerogeradorDto.Tecnologia, result?.Tecnologia);
            _aerogeradorRepositoryMock.Verify(repo => repo.Editar(It.IsAny<AerogeradorEntity>()), Times.Once);
        }

        [Fact]
        public void ExcluirAerogerador_DeveExcluirAerogeradorCorretamente()
        {
            // Arrange
            var aerogerador = new AerogeradorEntity { Id = 1, Modelo = "Modelo Para Deletar", Tecnologia = "Offshore" };

            _aerogeradorRepositoryMock.Setup(repo => repo.Excluir(1)).Returns(aerogerador);

            // Act
            var result = _aerogeradorApplicationService.ExcluirAerogerador(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Modelo Para Deletar", result?.Modelo);
            _aerogeradorRepositoryMock.Verify(repo => repo.Excluir(1), Times.Once);
        }
    }
}
