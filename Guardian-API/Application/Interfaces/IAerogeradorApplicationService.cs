using Guardian_API.Application.Dtos;
using Guardian_API.Domain.Entities;

namespace Guardian_API.Application.Interfaces
{
    public interface IAerogeradorApplicationService
    {
        IEnumerable<AerogeradorEntity>? ObterAerogeradores();
        AerogeradorEntity? ObterAerogeradorPorId(int id);
        AerogeradorEntity? AdicionarAerogerador(AerogeradorDto aerogerador);
        AerogeradorEntity? EditarAerogerador(int id, AerogeradorDto aerogerador);
        AerogeradorEntity? ExcluirAerogerador(int id);
    }
}
