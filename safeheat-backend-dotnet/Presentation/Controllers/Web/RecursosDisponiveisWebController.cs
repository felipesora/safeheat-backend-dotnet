using Microsoft.AspNetCore.Mvc;
using safeheat_backend_dotnet.Application.Dtos;
using safeheat_backend_dotnet.Application.Interfaces;

namespace safeheat_backend_dotnet.Presentation.Controllers.Web;

public class RecursosDisponiveisWebController : Controller
{
    private readonly IRecursoDisponivelApplication _recursoApplication;

    public RecursosDisponiveisWebController(IRecursoDisponivelApplication recursoApplication)
    {
        _recursoApplication = recursoApplication;
    }

    // Listar recursos de um abrigo
    public IActionResult Index(int abrigoId)
    {
        var recursos = _recursoApplication.ObterTodos()
            .Where(r => r.AbrigoId == abrigoId)
            .ToList();

        ViewBag.AbrigoId = abrigoId;
        return View(recursos);
    }

    // Tela de cadastro do recurso (GET)
    public IActionResult Create(int abrigoId)
    {
        var dto = new RecursoDisponivelDto { AbrigoId = abrigoId };
        return View(dto);
    }

    // Cadastro do recurso (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RecursoDisponivelDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        _recursoApplication.Salvar(dto);
        return RedirectToAction(nameof(Index), new { abrigoId = dto.AbrigoId });
    }

    // Tela de edição (GET)
    public IActionResult Edit(int id)
    {
        var recurso = _recursoApplication.ObterPorId(id);
        if (recurso == null) return NotFound();

        var dto = new RecursoDisponivelDto
        {
            Nome = recurso.Nome,
            Quantidade = recurso.Quantidade,
            AbrigoId = recurso.AbrigoId
        };

        ViewBag.Id = id;
        return View(dto);
    }

    // Edição do recurso (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, RecursoDisponivelDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Id = id;
            return View(dto);
        }

        _recursoApplication.Editar(id, dto);
        return RedirectToAction(nameof(Index), new { abrigoId = dto.AbrigoId });
    }

    // Deletar recurso
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, int abrigoId)
    {
        _recursoApplication.Deletar(id);
        return RedirectToAction(nameof(Index), new { abrigoId });
    }
}
