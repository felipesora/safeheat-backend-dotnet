using Microsoft.AspNetCore.Mvc;
using safeheat_backend_dotnet.Application.DTOs;
using safeheat_backend_dotnet.Application.Interfaces;

namespace safeheat_backend_dotnet.Presentation.Controllers.Web;

public class AbrigosWebController : Controller
{
    private readonly IAbrigoApplication _abrigoApplication;

    public AbrigosWebController(IAbrigoApplication abrigoApplication)
    {
        _abrigoApplication = abrigoApplication;
    }

    // Listar todos os abrigos
    public IActionResult Index()
    {
        var abrigos = _abrigoApplication.ObterTodos();
        return View(abrigos);
    }

    // Tela de cadastro de abrigo (GET)
    public IActionResult Create()
    {
        return View();
    }

    // Cadastro do abrigo (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AbrigoDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        _abrigoApplication.Salvar(dto);
        return RedirectToAction(nameof(Index));
    }

    // Tela de edição (GET)
    public IActionResult Edit(int id)
    {
        var abrigo = _abrigoApplication.ObterPorId(id);
        if (abrigo == null) return NotFound();

        var dto = new AbrigoDto
        {
            Nome = abrigo.Nome,
            Endereco = abrigo.Endereco,
            Cidade = abrigo.Cidade,
            CapacidadeTotal = abrigo.CapacidadeTotal,
            CapacidadeAtual = abrigo.CapacidadeAtual
        };

        return View(dto);
    }

    // Edição do abrigo (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, AbrigoDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        _abrigoApplication.Editar(id, dto);
        return RedirectToAction(nameof(Index));
    }

    // Deletar abrigo
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _abrigoApplication.Deletar(id);
        return RedirectToAction(nameof(Index));
    }

    // Ver recursos do abrigo
    public IActionResult Recursos(int abrigoId)
    {
        return RedirectToAction("Index", "RecursosDisponiveisWeb", new { abrigoId });
    }
}
