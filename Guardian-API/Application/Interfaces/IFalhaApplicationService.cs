using Guardian_API.Application.Dtos;
using Guardian_API.Domain.Entities;

namespace Guardian_API.Application.Interfaces
{
    public interface IFalhaApplicationService
    {
        IEnumerable<FalhaEntity>? ObterFalhas();
        FalhaEntity? ObterFalhaPorId(int id);
        FalhaEntity? AdicionarFalha(FalhaDto falha);
        FalhaEntity? EditarFalha(int id, FalhaDto falha);
        FalhaEntity? ExcluirFalha(int id);
    }
}
