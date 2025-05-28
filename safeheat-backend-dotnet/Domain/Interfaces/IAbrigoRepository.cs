using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Domain.Interfaces;

public interface IAbrigoRepository
{
    IEnumerable<Abrigo>? ObterTodos();
    Abrigo? ObterPorId(int id);
    Abrigo? Salvar(Abrigo abrigo);
    Abrigo? Editar(int id, Abrigo abrigo);
    Abrigo? Deletar(int id);
}
