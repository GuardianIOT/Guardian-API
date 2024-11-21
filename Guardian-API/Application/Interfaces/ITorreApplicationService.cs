using Guardian_API.Application.Dtos;
using Guardian_API.Domain.Entities;

namespace Guardian_API.Application.Interfaces
{
    public interface ITorreApplicationService
    {
        IEnumerable<TorreEntity>? ObterTorres();
        TorreEntity? ObterTorrePorId(int id);
        TorreEntity? AdicionarTorre(TorreDto torre);
        TorreEntity? EditarTorre(int id, TorreDto torre);
        TorreEntity? ExcluirTorre(int id);
    }
}
