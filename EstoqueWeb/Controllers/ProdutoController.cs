using EstoqueWeb.Application;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;

public class ProdutoController(IProdutoServices produtoServices) : Controller
{
    public IActionResult CadastrarProduto()
    {
        return View();
    }
    public async Task<IActionResult> Index([FromQuery]string produtoNome)
    {
        return View(nameof(Index), await produtoServices.GetProdutos(produtoNome));
    }

    public async Task<IActionResult> Details(int id)
    {
        var produto = await produtoServices.GetProduto(id);

        if(produto is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Details), produto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await produtoServices.Delete(id);

        return RedirectToAction(nameof(Index));
    }



    public async Task<IActionResult> Update(int id)
    {
        var produto = await produtoServices.GetProduto(id);

        if (produto is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(nameof(Update), produto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, Produto produto)
    {
        var pd = await produtoServices.GetProduto(id);

        if (pd is null)
        {
            return RedirectToAction(nameof(Index));
        }

        await produtoServices.Update(id, produto);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Produto produto)
    {
        await produtoServices.Create(produto);

        return RedirectToAction(nameof(Index));
    }
}
