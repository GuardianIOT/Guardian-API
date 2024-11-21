using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;
using Guardian_API.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Guardian_API.Infrastructure.Data.Repository
{
    public class ParqueRepository : IParqueRepository
    {
        private readonly ApplicationContext _context;

        public ParqueRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ParqueEntity>? ObterTodos()
        {
            var parques = _context.Parque
                   .Include(p => p.Aerogeradores) 
                   .ToList();

            if (parques.Any())
                return parques;

            return null;
        }

        public ParqueEntity? ObterPorId(int id)
        {
            var parques = _context.Parque.Find(id);

            if(parques is not null)
                return parques;

            return null;
        }

        public ParqueEntity? Adicionar(ParqueEntity parque)
        {
            try
            {
                _context.Add(parque);
                _context.SaveChanges();

                return parque;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel adicionar os dados");
            }
        }

        public ParqueEntity? Editar(ParqueEntity parque)
        {
            try
            {
                var parques = _context.Parque.Find(parque.Id);

                if (parques is not null)
                {
                    parques.Nome = parque.Nome;
                    parques.AnoInauguracao = parque.AnoInauguracao;
                    parques.AreaKm = parque.AreaKm;
                    parques.Tecnologia = parque.Tecnologia;
                    parques.StatusOperacao = parque.StatusOperacao;
                    parques.NumeroAerogeradores = parque.NumeroAerogeradores;

                    _context.Update(parques);
                    _context.SaveChanges();

                    return parques;
                }
                throw new Exception("Não foi possivel atualizar os dados");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ParqueEntity? Excluir(int id)
        {
            try
            {
                var parque = _context.Parque.Find(id);

                if (parque is not null)
                {
                    _context.Remove(parque);
                    _context.SaveChanges();

                    return parque;
                }

                throw new Exception("Registro não encontrado para exclusão");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir o registro: {ex.Message}", ex);
            }
        }

    }
}
