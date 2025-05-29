using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using safeheat_backend_dotnet.Application.DTOs;
using safeheat_backend_dotnet.Application.Interfaces;

namespace safeheat_backend_dotnet.Presentation.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class AbrigosApiController : ControllerBase
{
    private readonly IAbrigoApplication _service;

    public AbrigosApiController(IAbrigoApplication service)
    {
        _service = service;
    }

    [HttpGet]
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

    [HttpGet("{id}")]
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

    [HttpPost]
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

    [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
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
