using safeheat_backend_dotnet.Application.DTOs;
using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Application.Interfaces;

public interface IAbrigoApplication
{
    IEnumerable<AbrigoEntity>? ObterTodos();
    AbrigoEntity? ObterPorId(int id);
    AbrigoEntity? Salvar(AbrigoDto abrigo);
    AbrigoEntity? Editar(int id, AbrigoDto abrigo);
    AbrigoEntity? Deletar(int id);
}
