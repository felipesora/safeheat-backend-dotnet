using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using safeheat_backend_dotnet.Application.DTOs;
using safeheat_backend_dotnet.Application.Interfaces;

namespace safeheat_backend_dotnet.Presentation.Controllers.Api;

/// <summary>
/// Controlador responsável por operações com abrigos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AbrigosApiController : ControllerBase
{
    private readonly IAbrigoApplication _service;

    public AbrigosApiController(IAbrigoApplication service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todos os abrigos cadastrados.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna uma lista de todos os abrigos registrados no sistema.
    /// Retorna status 204 (No Content) caso não existam abrigos.
    /// </remarks>
    /// <returns>
    /// Retorna 200 OK com a lista dos abrigos, ou 204 caso não haja dados.
    /// </returns>
    /// <response code="200">Lista de abrigos retornada com sucesso.</response>
    /// <response code="204">Nenhum abrigo encontrado.</response>
    /// <response code="400">Erro ao tentar buscar os abrigos.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AbrigoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ObterTodos()
    {
        try
        {
            var abrigos = _service.ObterTodos();

            if (!abrigos.Any())
                return NoContent();

            return Ok(abrigos);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar os abrigos: {ex.Message}");
        }
    }

    /// <summary>
    /// Retorna o abrigo cadastrado com este id.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna o abrigo registrado no sistema com o id passado por parâmetro.
    /// Retorna status 404 (Not Found) caso não exista o abrigo com este id.
    /// </remarks>
    /// <returns>
    /// Retorna 200 OK com o abrigo, ou 404 caso não haja abrigo com este id.
    /// </returns>
    /// <response code="200">Abrigo com este id retornado com sucesso.</response>
    /// <response code="404">Nenhum abrigo com este id encontrado.</response>
    /// <response code="400">Erro ao tentar buscar o abrigo.</response>
    /// <param name="id">ID do abrigo a ser consultado. Deve ser um número inteiro maior que zero.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AbrigoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ObterPorId([FromRoute] int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("ID deve ser maior que zero.");

            var abrigo = _service.ObterPorId(id);

            if (abrigo == null)
                return NotFound($"Abrigo com ID {id} não encontrado.");

            return Ok(abrigo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar o abrigo com este ID: {ex.Message}");
        }

    }

    /// <summary>
    /// Cadastra um novo abrigo no sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint recebe os dados de um novo abrigo e o registra no sistema. 
    /// É necessário enviar um objeto JSON no corpo da requisição com os dados obrigatórios:
    /// - descricao
    /// - prioridade (BAIXA, MEDIA, ALTA)
    /// - status (ABERTA, EM_ANDAMENTO, FINALIZADA)
    /// - dataFinalizacao
    /// - responsavel
    /// - placaMoto
    /// 
    /// Exemplo de corpo (JSON):
    ///{
    ///"descricao": "Arrumar motor da moto",
    ///"prioridade": "MEDIA",
    ///"status": "EM_ANDAMENTO",
    ///"dataAbertura": "2025-05-13T21:59:20.953Z",
    ///"dataFinalizacao": "2025-06-07T09:00:00.953Z",
    ///"responsavel": "Felipe Sora",
    ///"placaMoto": "ABC1234"
    ///}
    /// </remarks>
    /// <param name="entity">Objeto com os dados do novo abrigo.</param>
    /// <returns>Retorna 200 OK com o abrigo cadastrado ou 400 Bad Request em caso de erro.</returns>
    /// <response code="200">Abrigo cadastrado com sucesso.</response>
    /// <response code="400">Erro ao tentar salvar o abrigo.</response>
    [HttpPost]
    [ProducesResponseType(typeof(AbrigoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Salvar([FromBody] AbrigoDto entity)
    {
        try
        {
            var abrigo = _service.Salvar(entity);

            return Ok(abrigo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar salvar este abrigo: {ex.Message} | Detalhes: {ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Atualiza os dados de um abrigo existente.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite atualizar as informações de um abrigo cadastrado no sistema.
    /// O ID do abrigo deve ser informado na rota e os novos dados devem ser enviados no corpo da requisição.
    /// Retorna 404 caso o abrigo não exista.
    /// </remarks>
    /// <param name="id">ID do abrigo a ser atualizado. Deve ser um número inteiro maior que zero.</param>
    /// <param name="entity">Objeto com os novos dados do abrigo.</param>
    /// <returns>Retorna o abrigo atualizado ou uma mensagem de erro.</returns>
    /// <response code="200">Abrigo atualizado com sucesso.</response>
    /// <response code="404">Abrigo com o ID especificado não foi encontrado.</response>
    /// <response code="400">Erro ao tentar atualizar o abrigo.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AbrigoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Editar([FromRoute] int id, [FromBody] AbrigoDto entity)
    {
        try
        {
            var abrigoAtualizado = _service.Editar(id, entity);

            if (abrigoAtualizado == null)
                return NotFound($"Abrigo com ID {id} não encontrado.");

            return Ok(abrigoAtualizado);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar editar este abrigo: {ex.Message}");
        }
    }

    /// <summary>
    /// Remove o abrigo do sistema com o id especificado.
    /// </summary>
    /// <remarks>
    /// Este endpoint remove um abrigo registrado no sistema, identificado pelo ID passado como parâmetro na rota.
    /// Retorna 404 caso o abrigo não seja encontrado.
    /// </remarks>
    /// <param name="id">ID do abrigo a ser removido. Deve ser um número inteiro maior que zero.</param>
    /// <returns>Retorna o status de sucesso ou falha dependendo do resultado da remoção.</returns>
    /// <response code="200">Abrigo removido com sucesso.</response>
    /// <response code="404">Abrigo com o ID especificado não encontrado.</response>
    /// <response code="400">Erro ao tentar remover o abrigo.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(AbrigoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Deletar(int id)
    {
        try
        {
            var abrigo = _service.Deletar(id);

            if (abrigo == null)
                return NotFound($"Alerta com ID {id} não encontrado.");

            return Ok(abrigo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar remover este abrigo: {ex.Message}");
        }
    }
}
