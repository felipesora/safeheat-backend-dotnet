using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Domain.Interfaces;

public interface IRegistroDeEntradaRepository
{
    IEnumerable<RegistroDeEntrada>? ObterTodos();
    RegistroDeEntrada? ObterPorId(int id);
    RegistroDeEntrada? Salvar(RegistroDeEntrada registro);
    RegistroDeEntrada? Editar(int id, RegistroDeEntrada registro);
    RegistroDeEntrada? Deletar(int id);
}
