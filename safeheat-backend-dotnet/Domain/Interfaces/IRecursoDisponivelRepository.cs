using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Domain.Interfaces;

public interface IRecursoDisponivelRepository
{
    IEnumerable<RecursoDisponivelEntity>? ObterTodos();
    RecursoDisponivelEntity? ObterPorId(int id);
    RecursoDisponivelEntity? Salvar(RecursoDisponivelEntity recurso);
    RecursoDisponivelEntity? Editar(int id, RecursoDisponivelEntity recurso);
    RecursoDisponivelEntity? Deletar(int id);
}
