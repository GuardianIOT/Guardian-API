using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;

namespace Guardian_API.Application.Services
{
    public class ParqueApplicationService : IParqueApplicationService
    {
        private readonly IParqueRepository _parqueRepository;

        public ParqueApplicationService(IParqueRepository parqueRepository)
        {
            _parqueRepository = parqueRepository;
        }

        public IEnumerable<ParqueEntity>? ObterParques()
        {
            return _parqueRepository.ObterTodos();
        }

        public ParqueEntity? ObterParquePorId(int id)
        {
            return _parqueRepository.ObterPorId(id);
        }

        public ParqueEntity? AdicionarParque(ParqueDto parqueDto)
        {
            var parque = new ParqueEntity
            {
                Nome = parqueDto.Nome,
                AnoInauguracao = parqueDto.AnoInauguracao,
                AreaKm = parqueDto.AreaKm,
                Tecnologia = parqueDto.Tecnologia,
                StatusOperacao = parqueDto.StatusOperacao,
                NumeroAerogeradores = parqueDto.NumeroAerogeradores,
            };

            return _parqueRepository.Adicionar(parque);
        }

        public ParqueEntity? EditarParque(int id, ParqueDto parqueDto)
        {
            var parque = new ParqueEntity
            {
                Id = id,
                Nome = parqueDto.Nome,
                AnoInauguracao = parqueDto.AnoInauguracao,
                AreaKm = parqueDto.AreaKm,
                Tecnologia = parqueDto.Tecnologia,
                StatusOperacao = parqueDto.StatusOperacao,
                NumeroAerogeradores = parqueDto.NumeroAerogeradores,
            };

            return _parqueRepository.Editar(parque);
        }

        public ParqueEntity? ExcluirParque(int id)
        {
            return _parqueRepository.Excluir(id);
        }
    }
}
