using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;

namespace Guardian_API.Application.Services
{
    public class FalhaApplicationService : IFalhaApplicationService
    {
        private readonly IFalhaRepository _falhaRepository;

        public FalhaApplicationService(IFalhaRepository falhaRepository)
        {
            _falhaRepository = falhaRepository;
        }

        public IEnumerable<FalhaEntity>? ObterFalhas()
        {
            return _falhaRepository.ObterTodos();
        }

        public FalhaEntity? ObterFalhaPorId(int id)
        {
            return _falhaRepository.ObterPorId(id);
        }

        public FalhaEntity? AdicionarFalha(FalhaDto falhaDto)
        {
            var falha = new FalhaEntity
            {
                DataHora = falhaDto.DataHora,
                Descricao = falhaDto.Descricao,
                Status = falhaDto.Status,
                Prioridade = falhaDto.Prioridade,
                Tipo = falhaDto.Tipo,
                EquipeManutencaoResponsavel = falhaDto.EquipeManutencaoResponsavel,
                DataResolucao = falhaDto.DataResolucao,
            };

            return _falhaRepository.Adicionar(falha);
        }

        public FalhaEntity? EditarFalha(int id, FalhaDto falhaDto)
        {
            var falha = new FalhaEntity
            {
                DataHora = falhaDto.DataHora,
                Descricao = falhaDto.Descricao,
                Status = falhaDto.Status,
                Prioridade = falhaDto.Prioridade,
                Tipo = falhaDto.Tipo,
                EquipeManutencaoResponsavel = falhaDto.EquipeManutencaoResponsavel,
                DataResolucao = falhaDto.DataResolucao,
            };

            return _falhaRepository.Editar(falha);
        }

        public FalhaEntity? ExcluirFalha(int id)
        {
            return _falhaRepository.Excluir(id);
        }
    }
}
