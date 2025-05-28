using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Domain.Interfaces;

public interface IRegistroDeEntradaRepository
{
    IEnumerable<RegistroDeEntradaEntity>? ObterTodos();
    RegistroDeEntradaEntity? ObterPorId(int id);
    RegistroDeEntradaEntity? Salvar(RegistroDeEntradaEntity registro);
    RegistroDeEntradaEntity? Editar(int id, RegistroDeEntradaEntity registro);
    RegistroDeEntradaEntity? Deletar(int id);
}
