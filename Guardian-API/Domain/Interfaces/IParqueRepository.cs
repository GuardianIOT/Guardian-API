using Guardian_API.Domain.Entities;

namespace Guardian_API.Domain.Interfaces
{
    public interface IParqueRepository
    {
        IEnumerable<ParqueEntity> ObterTodos();
        ParqueEntity? ObterPorId(int id);
        ParqueEntity? Adicionar(ParqueEntity parque);
        ParqueEntity? Editar(ParqueEntity parque);
        ParqueEntity? Excluir(int id);
    }
}
