using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;
using Guardian_API.Infrastructure.Data.AppData;

namespace Guardian_API.Infrastructure.Data.Repository
{
    public class FalhaRepository : IFalhaRepository
    {
        private readonly ApplicationContext _context;

        public FalhaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<FalhaEntity>? ObterTodos()
        {
            var falha = _context.Falha.ToList();

            if (falha.Any())
                return falha;

            return null;
        }

        public FalhaEntity? ObterPorId(int id)
        {
            var falha = _context.Falha.Find(id);

            if (falha == null)
                return falha;

            return null;
        }

        public FalhaEntity? Adicionar(FalhaEntity falha)
        {
            try
            {
                _context.Add(falha);
                _context.SaveChanges();

                return falha;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel adicionar os dados");
            }
        }

        public FalhaEntity? Editar(FalhaEntity falha)
        {
            try
            {
                var falhas = _context.Falha.Find(falha.Id);

                if (falhas is not null)
                {
                    falhas.Aerogeradores = falha.Aerogeradores;
                    falhas.DataHora = falha.DataHora;
                    falhas.Descricao = falha.Descricao;
                    falhas.Status = falhas.Status;
                    falhas.Prioridade = falha.Prioridade;
                    falhas.Tipo = falha.Tipo;
                    falhas.EquipeManutencaoResponsavel = falha.EquipeManutencaoResponsavel;
                    falhas.DataResolucao = falha.DataResolucao;

                    _context.Update(falhas);
                    _context.SaveChanges();

                    return falhas;
                }
                throw new Exception("Não foi possivel atualizar os dados");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public FalhaEntity? Excluir(int id)
        {
            try
            {
                var falha = _context.Falha.Find(id);

                if (falha is not null)
                {
                    _context.Remove(id);
                    _context.SaveChanges();

                    return falha;
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
