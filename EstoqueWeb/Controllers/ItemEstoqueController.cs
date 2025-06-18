using EstoqueWeb.Application;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;

public class ItemEstoqueController(IItemEstoqueServices itemEstoqueServices, ILojaServices lojaServices, IProdutoServices produtoServices) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(nameof(Index), await itemEstoqueServices.GetItemEstoquesTotais());
    }


    public async Task<IActionResult> Details(int id)
    {
        var ItemEstoque = await itemEstoqueServices.GetItemEstoque(id);

        if (ItemEstoque is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Details), ItemEstoque);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await itemEstoqueServices.Delete(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var ItemEstoque = await itemEstoqueServices.GetItemEstoque(id);

        if (ItemEstoque is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Update), ItemEstoque);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, ItemEstoque itemEstoque)
    {
        var pd = await itemEstoqueServices.GetItemEstoque(id);

        if (pd is null)
        {
            return RedirectToAction(nameof(Index));
        }

        await itemEstoqueServices.Update(id, itemEstoque);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> CadastrarItem()
    {
        var itemEstoque = await itemEstoqueServices.GetItemEstoques();

        var vw = new ItemEstoqueCreate()
        {
            Lojas = await lojaServices.GetLojas() ?? [],
            Produtos = await produtoServices.GetProdutos() ?? [],
        };
        return View(nameof(CadastrarItem), vw);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ItemEstoqueCreate itemEstoqueCreate)
    {
        var itemEstoque = new ItemEstoque()
        {
            Id = itemEstoqueCreate.ItemEstoque.Id,
            ProdutoId = itemEstoqueCreate.ItemEstoque.ProdutoId,
            LojaId = itemEstoqueCreate.ItemEstoque.LojaId,
            Quantidade = itemEstoqueCreate.ItemEstoque.Quantidade,

        };

        await itemEstoqueServices.Create(itemEstoque);

        return RedirectToAction(nameof(Index));
    }
}
