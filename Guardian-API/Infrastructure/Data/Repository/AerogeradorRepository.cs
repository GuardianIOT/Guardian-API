using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;
using Guardian_API.Infrastructure.Data.AppData;

namespace Guardian_API.Infrastructure.Data.Repository
{
    public class AerogeradorRepository : IAerogeradorRepository
    {
        private readonly ApplicationContext _context;

        public AerogeradorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<AerogeradorEntity>? ObterTodos()
        {
            var aerogerador = _context.Aerogerador.ToList();

            if (aerogerador.Any())
                return aerogerador;

            return null;
        }

        public AerogeradorEntity? ObterPorId(int id)
        {
            var aerogerador = _context.Aerogerador.Find(id);

            if (aerogerador is not null)
                return aerogerador;

            return null;
        }

        public AerogeradorEntity? Adicionar(AerogeradorEntity aerogerador)
        {
            try
            {
                _context.Add(aerogerador);
                _context.SaveChanges();

                return aerogerador;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel adicionar os dados");
            }
        }

        public AerogeradorEntity? Editar(AerogeradorEntity aerogerador)
        {
            try
            {
                var aerogeradores = _context.Aerogerador.Find(aerogerador.Id);

                if (aerogeradores is not null)
                {
                    aerogeradores.Modelo = aerogerador.Modelo;
                    aerogeradores.Tecnologia = aerogerador.Tecnologia;
                    aerogeradores.CapacidadeMW = aerogerador.CapacidadeMW;
                    aerogeradores.AlturaMastro = aerogerador.AlturaMastro;
                    aerogeradores.VelocidadeCorte = aerogerador.VelocidadeCorte;
                    aerogeradores.StatusOperacao = aerogerador.StatusOperacao;
                    aerogeradores.DiametroMotor = aerogerador.DiametroMotor;
                    aerogeradores.DataInstalacao = aerogerador.DataInstalacao;
                    aerogeradores.Garantia = aerogerador.Garantia;

                    _context.Update(aerogeradores);
                    _context.SaveChanges();

                    return aerogeradores;
                }
                throw new Exception("Não foi possivel atualizar os dados");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public AerogeradorEntity? Excluir(int id)
        {
            try
            {
                var aerogeradores = _context.Aerogerador.Find(id);

                if (aerogeradores is not null)
                {
                    _context.Remove(id);
                    _context.SaveChanges();

                    return aerogeradores;
                }
                throw new Exception("Não foi possivel remover os dados");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
