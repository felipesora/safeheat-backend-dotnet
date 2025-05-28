using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Domain.Interfaces;

public interface IAbrigoRepository
{
    IEnumerable<AbrigoEntity>? ObterTodos();
    AbrigoEntity? ObterPorId(int id);
    AbrigoEntity? Salvar(AbrigoEntity abrigo);
    AbrigoEntity? Editar(int id, AbrigoEntity abrigo);
    AbrigoEntity? Deletar(int id);
}
