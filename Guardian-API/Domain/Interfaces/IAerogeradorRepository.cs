using Guardian_API.Domain.Entities;

namespace Guardian_API.Domain.Interfaces
{
    public interface IAerogeradorRepository
    {
        IEnumerable<AerogeradorEntity> ObterTodos();
        AerogeradorEntity? ObterPorId(int id);
        AerogeradorEntity? Adicionar(AerogeradorEntity aerogerador);
        AerogeradorEntity? Editar(AerogeradorEntity aerogerador);
        AerogeradorEntity? Excluir(int id);
    }
}
