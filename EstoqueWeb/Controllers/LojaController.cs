using EstoqueWeb.Application;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;

public class LojaController(ILojaServices lojaServices) : Controller
{
    public IActionResult CadastrarLoja()
    {
        return View();
    }
    public async Task<IActionResult> Index(string? lojaNome)
    {
        return View(nameof(Index), await lojaServices.GetLojas(lojaNome!));
    }

    public async Task<IActionResult> Details(int id)
    {
        var loja = await lojaServices.GetLoja(id);

        if (loja is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Details), loja);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await lojaServices.Delete(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var loja = await lojaServices.GetLoja(id);

        if (loja is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Update), loja);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, Loja loja)
    {
        var lj = await lojaServices.GetLoja(id);

        if (lj is null)
        {
            return RedirectToAction(nameof(Index));
        }

        await lojaServices.Update(id, loja);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Loja loja)
    {
        await lojaServices.Create(loja);

        return RedirectToAction(nameof(Index));
    }
}
