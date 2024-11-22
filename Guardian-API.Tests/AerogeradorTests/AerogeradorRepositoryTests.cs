
using Guardian_API.Domain.Entities;
using Guardian_API.Infrastructure.Data.AppData;
using Guardian_API.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Guardian_API.Tests.AerogeradorTests
{
    public class AerogeradorRepositoryTests
    {
        private ApplicationContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated(); 

            return context;
        }

        [Fact]
        public async Task ObterTodos_DeveRetornarTodosOsAerogeradores()
        {
            var context = GetDbContext();
            var repository = new AerogeradorRepository(context);

            var aerogerador1 = new AerogeradorEntity { Modelo = "Modelo 1", Tecnologia = "Onshore" };
            var aerogerador2 = new AerogeradorEntity { Modelo = "Modelo 2", Tecnologia = "Offshore" };

            context.Aerogerador.AddRange(aerogerador1, aerogerador2);
            await context.SaveChangesAsync();

            var result = repository.ObterTodos();

            Assert.NotNull(result);
            Assert.Equal(2, result?.Count());
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarAerogeradorCorreto_QuandoIdExiste()
        {
            var context = GetDbContext();
            var repository = new AerogeradorRepository(context);

            var aerogerador = new AerogeradorEntity { Modelo = "Modelo Teste", Tecnologia = "Onshore" };
            context.Aerogerador.Add(aerogerador);
            await context.SaveChangesAsync();

            var result = repository.ObterPorId(aerogerador.Id);

            Assert.NotNull(result);
            Assert.Equal("Modelo Teste", result?.Modelo);
        }

        [Fact]
        public async Task Adicionar_DeveAdicionarAerogeradorCorretamente()
        {
            var context = GetDbContext();
            var repository = new AerogeradorRepository(context);

            var aerogerador = new AerogeradorEntity { Modelo = "Modelo Adicionado", Tecnologia = "Onshore" };

            var result = repository.Adicionar(aerogerador);

            Assert.NotNull(result);
            Assert.Equal("Modelo Adicionado", result.Modelo);
            Assert.Single(context.Aerogerador);
        }

        [Fact]
        public async Task Editar_DeveEditarAerogeradorCorretamente()
        {
            var context = GetDbContext();
            var repository = new AerogeradorRepository(context);

            var aerogerador = new AerogeradorEntity { Modelo = "Modelo Original", Tecnologia = "Onshore" };
            context.Aerogerador.Add(aerogerador);
            await context.SaveChangesAsync();

            aerogerador.Modelo = "Modelo Editado";
            var result = repository.Editar(aerogerador);

            Assert.NotNull(result);
            Assert.Equal("Modelo Editado", result.Modelo);
        }

    }
}
