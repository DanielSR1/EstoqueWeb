using EstoqueWeb.Application;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;

public class ItemEstoqueController(IItemEstoqueServices ItemEstoqueServices) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(nameof(Index), await ItemEstoqueServices.GetItemEstoquesTotais());
    }


    public async Task<IActionResult> Details(int id)
    {
        var ItemEstoque = await ItemEstoqueServices.GetItemEstoque(id);

        if (ItemEstoque is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Details), ItemEstoque);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await ItemEstoqueServices.Delete(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var ItemEstoque = await ItemEstoqueServices.GetItemEstoque(id);

        if (ItemEstoque is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Update), ItemEstoque);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, ItemEstoque itemEstoque)
    {
        var pd = await ItemEstoqueServices.GetItemEstoque(id);

        if (pd is null)
        {
            return RedirectToAction(nameof(Index));
        }

        await ItemEstoqueServices.Update(id, itemEstoque);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult CadastrarItem()
    {
        return View(nameof(CadastrarItem));
    }

    [HttpPost]
    public async Task<IActionResult> Create(ItemEstoque itemEstoque)
    {
        await ItemEstoqueServices.Create(itemEstoque);

        return RedirectToAction(nameof(Index));
    }
}
