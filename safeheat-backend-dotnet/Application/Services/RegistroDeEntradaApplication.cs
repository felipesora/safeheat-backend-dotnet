using safeheat_backend_dotnet.Application.Dtos;
using safeheat_backend_dotnet.Application.Interfaces;
using safeheat_backend_dotnet.Domain.Entities;
using safeheat_backend_dotnet.Domain.Interfaces;

namespace safeheat_backend_dotnet.Application.Services;

public class RegistroDeEntradaApplication : IRegistroDeEntradaApplication
{
    private readonly IRecursoDisponivelRepository _registroApplication;

    public RegistroDeEntradaApplication(IRecursoDisponivelRepository registroApplication)
    {
        _registroApplication = registroApplication;
    }

    public IEnumerable<RegistroDeEntradaEntity>? ObterTodos()
    {
        return _registroApplication.ObterTodos() ?? Enumerable.Empty<RegistroDeEntradaEntity>();
    }

    public RegistroDeEntradaEntity? ObterPorId(int id)
    {
        return _registroApplication.ObterPorId(id);
    }

    public RegistroDeEntradaEntity? Salvar(RegistroDeEntradaDto dto)
    {
        var registro = new RegistroDeEntradaEntity
        {
            NomePessoa = dto.NomePessoa,
            AbrigoId = dto.AbrigoId
        };

        return _registroApplication.Salvar(registro);
    }

    public RegistroDeEntradaEntity? Editar(int id, RegistroDeEntradaDto dto)
    {
        var registro = new RegistroDeEntradaEntity
        {
            Id = id,
            NomePessoa = dto.NomePessoa,
            AbrigoId = dto.AbrigoId
        };

        return _registroApplication.Editar(id, registro);
    }

    public RegistroDeEntradaEntity? Deletar(int id)
    {
        return _registroApplication.Deletar(id);
    }

}
