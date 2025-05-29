using safeheat_backend_dotnet.Domain.Entities;
using safeheat_backend_dotnet.Domain.Interfaces;
using safeheat_backend_dotnet.Infrastructure.Data.AppData;

namespace safeheat_backend_dotnet.Infrastructure.Data.Repositores;

public class RecursoDisponivelRepository : IRecursoDisponivelRepository
{
    private readonly ApplicationContext _context;

    public RecursoDisponivelRepository(ApplicationContext context)
    {
        _context = context;
    }
    public IEnumerable<RecursoDisponivelEntity>? ObterTodos()
    {
        var recurso = _context.RecursoDisponivel.ToList();

        if (recurso.Any())
        {
            return recurso;
        }

        return null;
    }
    public RecursoDisponivelEntity? ObterPorId(int id)
    {
        var recurso = _context.RecursoDisponivel.Find(id);

        if (recurso is not null)
            return recurso;

        return null;
    }

    public RecursoDisponivelEntity? Salvar(RecursoDisponivelEntity recurso)
    {
        try
        {
            _context.RecursoDisponivel.Add(recurso);
            _context.SaveChanges();

            return recurso;
        }
        catch (Exception)
        {
            throw new Exception("Não foi possivel salvar o recurso");
        }
    }
    public RecursoDisponivelEntity? Editar(int id, RecursoDisponivelEntity recurso)
    {
        try
        {
            var recursoExistente = _context.RecursoDisponivel.Find(id);

            if (recursoExistente == null)
                return null;

            recursoExistente.Nome = recurso.Nome;
            recursoExistente.Quantidade = recurso.Quantidade;
            recursoExistente.AbrigoId = recurso.AbrigoId;

            _context.RecursoDisponivel.Update(recursoExistente);
            _context.SaveChanges();

            return recursoExistente;
        }
        catch (Exception)
        {
            throw new Exception("Não foi possivel atualizar o recurso");
        }

    }

    public RecursoDisponivelEntity? Deletar(int id)
    {
        try
        {
            var registro = _context.RecursoDisponivel.Find(id);

            if (registro is not null)
            {
                _context.RecursoDisponivel.Remove(registro);
                _context.SaveChanges();

                return registro;
            }

            throw new Exception("Não foi possivel localizar o recurso para seguir com a exclusão");

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }
}
