using Guardian_API.Domain.Entities;
using Guardian_API.Infrastructure.Data.AppData;
using Guardian_API.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Guardian_API.Tests.ParqueTests
{
    public class ParqueRepositoryTests
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
        public async Task ObterTodos_DeveRetornarTodosOsParques()
        {
            var context = GetDbContext();
            var repository = new ParqueRepository(context);

            var parque1 = new ParqueEntity { Nome = "Parque 1", AnoInauguracao = DateTime.Now };
            var parque2 = new ParqueEntity { Nome = "Parque 2", AnoInauguracao = DateTime.Now };

            context.Parque.AddRange(parque1, parque2);
            await context.SaveChangesAsync();

            var result = repository.ObterTodos();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarParqueCorreto()
        {
            var context = GetDbContext();
            var repository = new ParqueRepository(context);

            var parque = new ParqueEntity { Nome = "Parque Teste", AnoInauguracao = DateTime.Now };
            context.Parque.Add(parque);
            await context.SaveChangesAsync();

            var result = repository.ObterPorId(parque.Id);

            Assert.NotNull(result);
            Assert.Equal("Parque Teste", result?.Nome);
        }

        [Fact]
        public async Task Adicionar_DeveAdicionarParqueCorretamente()
        {
            var context = GetDbContext();
            var repository = new ParqueRepository(context);

            var parque = new ParqueEntity { Nome = "Parque Adicionado", AnoInauguracao = DateTime.Now };

            var result = repository.Adicionar(parque);

            Assert.NotNull(result);
            Assert.Equal("Parque Adicionado", result.Nome);
            Assert.Single(context.Parque);
        }

        [Fact]
        public async Task Editar_DeveEditarParqueCorretamente()
        {
            var context = GetDbContext();
            var repository = new ParqueRepository(context);

            var parque = new ParqueEntity { Nome = "Parque Original", AnoInauguracao = DateTime.Now };
            context.Parque.Add(parque);
            await context.SaveChangesAsync();

            parque.Nome = "Parque Editado";
            var result = repository.Editar(parque);

            Assert.NotNull(result);
            Assert.Equal("Parque Editado", result.Nome);
        }

        [Fact]
        public async Task Excluir_DeveRemoverParqueCorretamente()
        {
            var context = GetDbContext();
            var repository = new ParqueRepository(context);

            var parque = new ParqueEntity { Nome = "Parque para Deletar", AnoInauguracao = DateTime.Now };
            context.Parque.Add(parque);
            await context.SaveChangesAsync();

            var result = repository.Excluir(parque.Id);

            Assert.NotNull(result);
            Assert.Equal("Parque para Deletar", result.Nome);
            Assert.Empty(context.Parque);
        }

    }
}
