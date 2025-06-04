using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using safeheat_backend_dotnet.Application.Dtos;
using safeheat_backend_dotnet.Application.DTOs;
using safeheat_backend_dotnet.Application.Interfaces;

namespace safeheat_backend_dotnet.Presentation.Controllers.Api;

/// <summary>
/// Controlador responsável por operações com recursos disponiveis.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RecursosDisponiveisApiController : ControllerBase
{
    private readonly IRecursoDisponivelApplication _service;

    public RecursosDisponiveisApiController(IRecursoDisponivelApplication service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todos os recursos disponiveis cadastrados.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna uma lista de todos os recursos disponiveis registrados no sistema.
    /// Retorna status 204 (No Content) caso não existam recursos disponiveis.
    /// </remarks>
    /// <returns>
    /// Retorna 200 OK com a lista dos recursos disponiveis, ou 204 caso não haja dados.
    /// </returns>
    /// <response code="200">Lista de recursos disponiveis retornada com sucesso.</response>
    /// <response code="204">Nenhum recursos disponiveis encontrado.</response>
    /// <response code="400">Erro ao tentar buscar os recursos disponiveis.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RecursoDisponivelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ObterTodos()
    {
        try
        {
            var recursos = _service.ObterTodos();

            if (!recursos.Any())
                return NoContent();

            return Ok(recursos);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar os recursos: {ex.Message}");
        }
    }

    /// <summary>
    /// Retorna o recurso disponivel cadastrado com este id.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna o recurso disponivel registrado no sistema com o id passado por parâmetro.
    /// Retorna status 404 (Not Found) caso não exista o recurso disponivel com este id.
    /// </remarks>
    /// <returns>
    /// Retorna 200 OK com o recurso disponivel, ou 404 caso não haja recurso disponivel com este id.
    /// </returns>
    /// <response code="200">Recurso disponivel com este id retornado com sucesso.</response>
    /// <response code="404">Nenhum recurso disponivel com este id encontrado.</response>
    /// <response code="400">Erro ao tentar buscar o recurso disponivel.</response>
    /// <param name="id">ID do recurso disponivel a ser consultado. Deve ser um número inteiro maior que zero.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RecursoDisponivelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ObterPorId([FromRoute] int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("ID deve ser maior que zero.");

            var recurso = _service.ObterPorId(id);

            if (recurso == null)
                return NotFound($"Recurso com ID {id} não encontrado.");

            return Ok(recurso);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar o recurso com este ID: {ex.Message}");
        }
    }

    /// <summary>
    /// Cadastra um novo recurso no sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint recebe os dados de um novo recurso e o registra no sistema. 
    /// É necessário enviar um objeto JSON no corpo da requisição com os dados obrigatórios:
    /// - Nome
    /// - Quantidade
    /// - ID do abrigo
    /// </remarks>
    /// <param name="entity">Objeto com os dados do novo recurso.</param>
    /// <returns>Retorna 200 OK com o recurso cadastrado ou 400 Bad Request em caso de erro.</returns>
    /// <response code="200">Recurso cadastrado com sucesso.</response>
    /// <response code="400">Erro ao tentar salvar o recurso.</response>
    [HttpPost]
    [ProducesResponseType(typeof(RecursoDisponivelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Salvar([FromBody] RecursoDisponivelDto dto)
    {
        try
        {
            var recurso = _service.Salvar(dto);

            return Ok(recurso);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar salvar este recurso: {ex.Message} | Detalhes: {ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Atualiza os dados de um recurso existente.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite atualizar as informações de um recurso cadastrado no sistema.
    /// O ID do recurso deve ser informado na rota e os novos dados devem ser enviados no corpo da requisição.
    /// Retorna 404 caso o recurso não exista.
    /// </remarks>
    /// <param name="id">ID do recurso a ser atualizado. Deve ser um número inteiro maior que zero.</param>
    /// <param name="entity">Objeto com os novos dados do recurso.</param>
    /// <returns>Retorna o recurso atualizado ou uma mensagem de erro.</returns>
    /// <response code="200">Recurso atualizado com sucesso.</response>
    /// <response code="404">Recurso com o ID especificado não foi encontrado.</response>
    /// <response code="400">Erro ao tentar atualizar o recurso.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(RecursoDisponivelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Editar([FromRoute] int id, [FromBody] RecursoDisponivelDto dto)
    {
        try
        {
            var recursoAtualizado = _service.Editar(id, dto);

            if (recursoAtualizado == null)
                return NotFound($"Recurso com ID {id} não encontrado.");

            return Ok(recursoAtualizado);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar editar este recurso: {ex.Message}");
        }
    }

    /// <summary>
    /// Remove o recurso do sistema com o id especificado.
    /// </summary>
    /// <remarks>
    /// Este endpoint remove um recurso registrado no sistema, identificado pelo ID passado como parâmetro na rota.
    /// Retorna 404 caso o recurso não seja encontrado.
    /// </remarks>
    /// <param name="id">ID do recurso a ser removido. Deve ser um número inteiro maior que zero.</param>
    /// <returns>Retorna o status de sucesso ou falha dependendo do resultado da remoção.</returns>
    /// <response code="200">Recurso removido com sucesso.</response>
    /// <response code="404">Recurso com o ID especificado não encontrado.</response>
    /// <response code="400">Erro ao tentar remover o recurso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(RecursoDisponivelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Deletar(int id)
    {
        try
        {
            var recurso = _service.Deletar(id);

            if (recurso == null)
                return NotFound($"Recurso com ID {id} não encontrado.");

            return Ok(recurso);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar remover este recurso: {ex.Message}");
        }
    }
}
