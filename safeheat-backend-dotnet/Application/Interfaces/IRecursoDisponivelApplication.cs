using safeheat_backend_dotnet.Application.Dtos;
using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Application.Interfaces;

public interface IRecursoDisponivelApplication
{
    IEnumerable<RecursoDisponivelEntity>? ObterTodos();
    RecursoDisponivelEntity? ObterPorId(int id);
    RecursoDisponivelEntity? Salvar(RecursoDisponivelDto registro);
    RecursoDisponivelEntity? Editar(int id, RecursoDisponivelDto registro);
    RecursoDisponivelEntity? Deletar(int id);
}
