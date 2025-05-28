using safeheat_backend_dotnet.Domain.Entities;
using safeheat_backend_dotnet.Domain.Interfaces;
using safeheat_backend_dotnet.Infrastructure.Data.AppData;

namespace safeheat_backend_dotnet.Infrastructure.Data.Repositores;

public class RegistroDeEntradaRepository : IRegistroDeEntradaRepository
{
    private readonly ApplicationContext _context;

    public RegistroDeEntradaRepository(ApplicationContext context)
    {
        _context = context;
    }
    public IEnumerable<RegistroDeEntradaEntity>? ObterTodos()
    {
        var registros = _context.RegistroDeEntrada.ToList();

        if (registros.Any())
        {
            return registros;
        }

        return null;
    }
    public RegistroDeEntradaEntity? ObterPorId(int id)
    {
        var registro = _context.RegistroDeEntrada.Find(id);

        if (registro is not null)
            return registro;

        return null;
    }

    public RegistroDeEntradaEntity? Salvar(RegistroDeEntradaEntity registro)
    {
        try
        {
            _context.RegistroDeEntrada.Add(registro);
            _context.SaveChanges();

            return registro;
        }
        catch (Exception)
        {
            throw new Exception("Não foi possivel salvar o registro");
        }
    }
    public RegistroDeEntradaEntity? Editar(int id, RegistroDeEntradaEntity registro)
    {
        try
        {
            var registroExistente = _context.RegistroDeEntrada.Find(id);

            if (registroExistente == null)
                return null;

            registroExistente.NomePessoa = registro.NomePessoa;
            registroExistente.DataEntrada = registro.DataEntrada;
            registroExistente.AbrigoId = registro.AbrigoId;

            _context.RegistroDeEntrada.Update(registroExistente);
            _context.SaveChanges();

            return registroExistente;
        }
        catch (Exception)
        {
            throw new Exception("Não foi possivel atualizar o registro");
        }

    }

    public RegistroDeEntradaEntity? Deletar(int id)
    {
        try
        {
            var registro = _context.RegistroDeEntrada.Find(id);

            if (registro is not null)
            {
                _context.RegistroDeEntrada.Remove(registro);
                _context.SaveChanges();

                return registro;
            }

            throw new Exception("Não foi possivel localizar o registro para seguir com a exclusão");

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }
}
