using Guardian_API.Domain.Entities;

namespace Guardian_API.Domain.Interfaces
{
    public interface ITorreRepository
    {
        IEnumerable<TorreEntity> ObterTodos();
        TorreEntity? ObterPorId(int id);
        TorreEntity? Adicionar(TorreEntity torre);
        TorreEntity? Editar(TorreEntity torre);
        TorreEntity? Excluir(int id);
    }
}
