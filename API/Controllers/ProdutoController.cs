using API.Application.Produto;
using API.Models.Produto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class ProdutoController (IProdutoService service) : ControllerBase 
{
    [HttpGet]
    [Route("produtos/")]

    public async Task<ActionResult<IEnumerable<ProdutosViewModel>>> GetProdutos([FromQuery]string? produtoNome)
    {
        return Ok(ProdutosViewModel.ToProdutosViewModel(await service.BuscaProdutos(produtoNome)));

    }

    [HttpGet]
    [Route("produtos/{id:int}")]
    public async Task<ActionResult<ProdutosViewModel>> GetProdutos(int id)
    {
        var produto = await service.BuscaProduto(id);

        if (produto is null)
        {
            return NoContent();
        }

        return Ok(produto);

    }

    [HttpPost]
    [Route("produtos/")]
    public async Task<IActionResult> Post([FromBody] ProdutosCreateViewModel produtoVw)
    {
        var adicionado = await service.AdicionaProduto(produtoVw);

        if(adicionado)
        {
            return Created();
        }

        return BadRequest();
    }


    [HttpPatch]
    [Route("produtos/{id:int}")]
    public async Task<IActionResult> Patch([FromRoute]int id, [FromBody] ProdutosPatchViewModel produtoVw)
    {
        var atualizado = await service.AtualizarProduto(id, produtoVw);

        if(atualizado)
        {
            return NoContent();
        }

        return BadRequest();

    }

    [HttpDelete]
    [Route("produtos/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletado = await service.DeleteProduto(id);

        if(deletado)
        {
            return Ok();
        }

        return BadRequest();
    }
}
