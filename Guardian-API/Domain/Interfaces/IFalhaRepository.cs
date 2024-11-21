using Guardian_API.Domain.Entities;

namespace Guardian_API.Domain.Interfaces
{
    public interface IFalhaRepository
    {
        IEnumerable<FalhaEntity> ObterTodos();
        FalhaEntity? ObterPorId(int id);
        FalhaEntity? Adicionar(FalhaEntity falha);
        FalhaEntity? Editar(FalhaEntity falha);
        FalhaEntity? Excluir(int id);
    }
}
