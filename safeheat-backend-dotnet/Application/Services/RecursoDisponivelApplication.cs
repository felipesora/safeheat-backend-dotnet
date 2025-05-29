using safeheat_backend_dotnet.Application.Dtos;
using safeheat_backend_dotnet.Application.Interfaces;
using safeheat_backend_dotnet.Domain.Entities;
using safeheat_backend_dotnet.Domain.Interfaces;

namespace safeheat_backend_dotnet.Application.Services;

public class RecursoDisponivelApplication : IRecursoDisponivelApplication
{
    private readonly IRecursoDisponivelRepository _recursoApplication;

    public RecursoDisponivelApplication(IRecursoDisponivelRepository recursoApplication)
    {
        _recursoApplication = recursoApplication;
    }

    public IEnumerable<RecursoDisponivelEntity>? ObterTodos()
    {
        return _recursoApplication.ObterTodos() ?? Enumerable.Empty<RecursoDisponivelEntity>();
    }

    public RecursoDisponivelEntity? ObterPorId(int id)
    {
        return _recursoApplication.ObterPorId(id);
    }

    public RecursoDisponivelEntity? Salvar(RecursoDisponivelDto dto)
    {
        var registro = new RecursoDisponivelEntity
        {
            Nome = dto.Nome,
            Quantidade = dto.Quantidade,
            AbrigoId = dto.AbrigoId
        };

        return _recursoApplication.Salvar(registro);
    }

    public RecursoDisponivelEntity? Editar(int id, RecursoDisponivelDto dto)
    {
        var registro = new RecursoDisponivelEntity
        {
            Id = id,
            Nome = dto.Nome,
            Quantidade = dto.Quantidade,
            AbrigoId = dto.AbrigoId
        };

        return _recursoApplication.Editar(id, registro);
    }

    public RecursoDisponivelEntity? Deletar(int id)
    {
        return _recursoApplication.Deletar(id);
    }

}
