using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;

namespace Guardian_API.Application.Services
{
    public class TorreApplicationService : ITorreApplicationService
    {
        private readonly ITorreRepository _torreRepository;

        public TorreApplicationService(ITorreRepository torreRepository)
        {
            _torreRepository = torreRepository;
        }

        public IEnumerable<TorreEntity>? ObterTorres()
        {
            return _torreRepository.ObterTodos();
        }

        public TorreEntity? ObterTorrePorId(int id)
        {
            return _torreRepository.ObterPorId(id);
        }

        public TorreEntity? AdicionarTorre(TorreDto torre)
        {
            var torres = new TorreEntity
            {
                Nome = torre.Nome,
                DataInstalacao = torre.DataInstalacao,
                StatusOperacao = torre.StatusOperacao,
                UltimaLeitura = torre.UltimaLeitura,
            };

            return _torreRepository.Adicionar(torres);
        }

        public TorreEntity? EditarTorre(int id, TorreDto torre)
        {
            var torres = new TorreEntity
            {
                Id = id,
                Nome = torre.Nome,
                DataInstalacao = torre.DataInstalacao,
                StatusOperacao = torre.StatusOperacao,
                UltimaLeitura = torre.UltimaLeitura,
            };

            return _torreRepository.Editar(torres);
        }

        public TorreEntity? ExcluirTorre(int id)
        {
            return _torreRepository.Excluir(id);
        }
    }
}
