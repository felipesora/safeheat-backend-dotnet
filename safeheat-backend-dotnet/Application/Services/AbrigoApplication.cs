﻿using safeheat_backend_dotnet.Application.DTOs;
using safeheat_backend_dotnet.Application.Interfaces;
using safeheat_backend_dotnet.Domain.Entities;
using safeheat_backend_dotnet.Domain.Interfaces;

namespace safeheat_backend_dotnet.Application.Services;

public class AbrigoApplication : IAbrigoApplication
{
    private readonly IAbrigoRepository _abrigoApplication;

    public AbrigoApplication(IAbrigoRepository abrigoApplication)
    {
        _abrigoApplication = abrigoApplication;
    }

    public IEnumerable<AbrigoEntity>? ObterTodos()
    {
        return _abrigoApplication.ObterTodos() ?? Enumerable.Empty<AbrigoEntity>();
    }

    public AbrigoEntity? ObterPorId(int id)
    {
        return _abrigoApplication.ObterPorId(id);
    }

    public AbrigoEntity? Salvar(AbrigoDto dto)
    {
        var abrigo = new AbrigoEntity
        {
            Nome = dto.Nome,
            CEP = dto.CEP,
            Rua = dto.Rua,
            Numero = dto.Numero,
            Bairro = dto.Bairro,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            CapacidadeTotal = dto.CapacidadeTotal,
            OcupacaoAtual = dto.OcupacaoAtual
        };

        return _abrigoApplication.Salvar(abrigo);
    }

    public AbrigoEntity? Editar(int id, AbrigoDto dto)
    {
        var abrigo = new AbrigoEntity
        {
            Id = id,
            Nome = dto.Nome,
            CEP = dto.CEP,
            Rua = dto.Rua,
            Numero = dto.Numero,
            Bairro = dto.Bairro,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            CapacidadeTotal = dto.CapacidadeTotal,
            OcupacaoAtual = dto.OcupacaoAtual
        };

        return _abrigoApplication.Editar(id, abrigo);
    }

    public AbrigoEntity? Deletar(int id)
    {
        return _abrigoApplication.Deletar(id);
    }

}
