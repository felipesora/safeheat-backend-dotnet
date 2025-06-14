﻿using Microsoft.EntityFrameworkCore;
using safeheat_backend_dotnet.Domain.Entities;
using safeheat_backend_dotnet.Domain.Interfaces;
using safeheat_backend_dotnet.Infrastructure.Data.AppData;

namespace safeheat_backend_dotnet.Infrastructure.Data.Repositores;

public class AbrigoRepository : IAbrigoRepository
{
    private readonly ApplicationContext _context;

    public AbrigoRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<AbrigoEntity>? ObterTodos()
    {
        var abrigos = _context.Abrigo
            .Include(a => a.RecursosDisponiveis)
            .ToList();

        if (abrigos.Any())
        {
            return abrigos;
        }

        return null;
    }

    public AbrigoEntity? ObterPorId(int id)
    {
        var abrigo = _context.Abrigo
        .Include(a => a.RecursosDisponiveis)
        .FirstOrDefault(a => a.Id == id);

        if (abrigo is not null)
        {
            return abrigo;
        }

        return null;
    }

    public AbrigoEntity? Salvar(AbrigoEntity abrigo)
    {
        try
        {
            _context.Abrigo.Add(abrigo);
            _context.SaveChanges();

            return abrigo;
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível salvar o abrigo", ex);
        }

    }

    public AbrigoEntity? Editar(int id, AbrigoEntity abrigo)
    {
        try
        {
            var abrigoExistente = _context.Abrigo.Find(id);

            if (abrigoExistente == null)
                return null;

            abrigoExistente.Nome = abrigo.Nome;
            abrigoExistente.CEP = abrigo.CEP;
            abrigoExistente.Rua = abrigo.Rua;
            abrigoExistente.Numero = abrigo.Numero;
            abrigoExistente.Bairro = abrigo.Bairro;
            abrigoExistente.Cidade = abrigo.Cidade;
            abrigoExistente.Estado = abrigo.Estado;
            abrigoExistente.CapacidadeTotal = abrigo.CapacidadeTotal;
            abrigoExistente.OcupacaoAtual = abrigo.OcupacaoAtual;

            _context.Abrigo.Update(abrigoExistente);
            _context.SaveChanges();

            return abrigoExistente;
        }
        catch (Exception)
        {
            throw new Exception("Não foi possivel atualizar o abrigo");
        }

    }

    public AbrigoEntity? Deletar(int id)
    {
        try
        {
            var abrigo = _context.Abrigo.Find(id);

            if (abrigo is not null)
            {
                _context.Abrigo.Remove(abrigo);
                _context.SaveChanges();

                return abrigo;
            }

            throw new Exception("Não foi possivel localizar o abrigo para seguir com a exclusão");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
