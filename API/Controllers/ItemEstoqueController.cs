using API.Application.ItemEstoque;
using API.DBContext;
using API.Models.ItemEstoque;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class ItemEstoquesController(IItemEstoqueService service, ApiDBContext context) : ControllerBase
{
    [HttpGet]
    [Route("ItemEstoques/Completo")]

    public async Task<ActionResult<ItemEstoquesViewModel>> GetItemEstoquesTotais()
    {
        var ItemEstoques = await service.BuscarItemsTotais();

        return Ok(ItemEstoques);

    }

    [HttpGet]
    [Route("ItemEstoques/")]

    public async Task<ActionResult<IEnumerable<ItemEstoquesViewModel>>> GetItemEstoques()
    {
        var ItemEstoques = await service.BuscaItemEstoques();

        return Ok(ItemEstoquesViewModel.ToItemEstoquesViewModel(ItemEstoques));

    }

    [HttpGet]
    [Route("ItemEstoques/{id:int}")]
    public async Task<ActionResult<ItemEstoquesViewModel>> GetItemEstoques(int id)
    {
        var ItemEstoques = await service.BuscaItemEstoque(id);

        if (ItemEstoques is null)
        {
            return NoContent();
        }

        return Ok(ItemEstoques);

    }

    [HttpPost]
    [Route("ItemEstoques/")]
    public async Task<IActionResult> Post([FromBody] ItemEstoquesCreateViewModel ItemEstoqueVw)
    {
        var adicionado = await service.AdicionaItemEstoque(ItemEstoqueVw);
        if (adicionado)
        {
            return Created();
        }

        return BadRequest();
    }

    [HttpPatch]
    [Route("ItemEstoques/{id:int}")]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] ItemEstoquesPatchViewModel itemEstoqueVw)
    {
        var atualizado = await service.AtualizarItemEstoque(id, itemEstoqueVw);

        if (atualizado)
        {
            return NoContent();
        }

        return BadRequest();
    }

    [HttpDelete]
    [Route("ItemEstoques/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ItemEstoqueRemovido = await service.DeleteItemEstoque(id);

        if (ItemEstoqueRemovido)
        {
            return Ok();
        }

        return BadRequest();
    }

}

