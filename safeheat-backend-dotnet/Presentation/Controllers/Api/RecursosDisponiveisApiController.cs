using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using safeheat_backend_dotnet.Application.Dtos;
using safeheat_backend_dotnet.Application.Interfaces;

namespace safeheat_backend_dotnet.Presentation.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class RecursosDisponiveisApiController : ControllerBase
{
    private readonly IRecursoDisponivelApplication _service;

    public RecursosDisponiveisApiController(IRecursoDisponivelApplication service)
    {
        _service = service;
    }

    [HttpGet]
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
            return BadRequest(new
            {
                Mensagem = "Erro ao buscar recursos disponíveis.",
                Erro = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
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
            return BadRequest(new
            {
                Mensagem = "Erro ao buscar o recurso.",
                Erro = ex.Message
            });
        }
    }

    [HttpPost]
    public IActionResult Salvar([FromBody] RecursoDisponivelDto dto)
    {
        try
        {
            var recurso = _service.Salvar(dto);

            return CreatedAtAction(nameof(ObterPorId), new { id = recurso?.Id }, recurso);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Mensagem = "Erro ao salvar o recurso.",
                Erro = ex.Message,
                Detalhes = ex.InnerException?.Message
            });
        }
    }

    [HttpPut("{id}")]
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
            return BadRequest(new
            {
                Mensagem = "Erro ao editar o recurso.",
                Erro = ex.Message
            });
        }
    }

    [HttpDelete("{id}")]
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
            return BadRequest(new
            {
                Mensagem = "Erro ao remover o recurso.",
                Erro = ex.Message
            });
        }
    }
}
