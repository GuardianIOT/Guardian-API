using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;
using Guardian_API.Infrastructure.Data.AppData;

namespace Guardian_API.Infrastructure.Data.Repository
{
    public class TorreRepository : ITorreRepository
    {
        private readonly ApplicationContext _context;

        public TorreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<TorreEntity>? ObterTodos()
        {
            var torres = _context.Torre.ToList();

            if (torres.Any())
                return torres;

            return null;
        }

        public TorreEntity? ObterPorId(int id)
        {
            var torres = _context.Torre.Find(id);

            if (torres is not null)
                return torres;

            return null;
        }

        public TorreEntity? Adicionar(TorreEntity? torre)
        {
            try
            {
                _context.Add(torre);
                _context.SaveChanges();

                return torre;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel adicionar os dados");
            }
        }

        public TorreEntity? Editar(TorreEntity? torre)
        {
            try
            {
                var torres = _context.Torre.Find(torre.Id);

                if (torres is not null)
                {
                    torres.Nome = torre.Nome;
                    torres.Localizacao = torre.Localizacao;
                    torres.DataInstalacao = torre.DataInstalacao;
                    torres.StatusOperacao = torre.StatusOperacao;
                    torres.UltimaLeitura = torre.UltimaLeitura;

                    _context.Update(torres);
                    _context.SaveChanges();

                    return torres;
                }
                throw new Exception("Não foi possivel atualizar os dados");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public TorreEntity? Excluir(int id)
        {
            try
            {
                var torres = _context.Torre.Find(id);

                if (torres is not null)
                {
                    _context.Remove(id);
                    _context.SaveChanges();

                    return torres;
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
