using Guardian_API.Application.Dtos;
using Guardian_API.Domain.Entities;

namespace Guardian_API.Application.Interfaces
{
    public interface IParqueApplicationService
    {
        IEnumerable<ParqueEntity>? ObterParques();
        ParqueEntity? ObterParquePorId(int id);
        ParqueEntity? AdicionarParque(ParqueDto parque);
        ParqueEntity? EditarParque(int id, ParqueDto parque);
        ParqueEntity? ExcluirParque(int id);
    }
}
