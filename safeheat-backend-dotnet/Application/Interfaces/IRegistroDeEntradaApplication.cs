using safeheat_backend_dotnet.Application.Dtos;
using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Application.Interfaces;

public interface IRegistroDeEntradaApplication
{
    IEnumerable<RegistroDeEntradaEntity>? ObterTodos();
    RegistroDeEntradaEntity? ObterPorId(int id);
    RegistroDeEntradaEntity? Salvar(RegistroDeEntradaDto registro);
    RegistroDeEntradaEntity? Editar(int id, RegistroDeEntradaDto registro);
    RegistroDeEntradaEntity? Deletar(int id);
}
