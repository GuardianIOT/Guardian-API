using Guardian_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guardian_API.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<AerogeradorEntity> Aerogerador { get; set; }
        public DbSet<LocalizacaoEntity> Localizacao { get; set; }
        public DbSet<ParqueEntity> Parque { get; set; }
        public DbSet<TorreEntity> Torre { get; set; }
        public DbSet<FalhaEntity> Falha { get; set; }
    }

}
