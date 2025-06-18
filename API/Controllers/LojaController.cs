using API.Application.Loja;
using API.Models.Loja;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class LojasController(ILojaService service) : ControllerBase
{
    [HttpGet]
    [Route("lojas/")]

    public async Task<ActionResult<IEnumerable<LojasViewModel>>> GetLojas()
    {
        var lojas = await service.BuscaLojas();

        return Ok(LojasViewModel.ToLojasViewModel(lojas));

    }

    [HttpGet]
    [Route("lojas/{id:int}")]
    public async Task<ActionResult<LojasViewModel>> GetLojas(int id)
    {
        var loja = await service.BuscaLoja(id);

        if (loja is null)
        {
            return NoContent();
        }

        return Ok(loja);

    }

    [HttpPost]
    [Route("lojas/")]
    public async Task<IActionResult> Post([FromBody] LojasCreateViewModel lojaVw)
    {
        var adicionado = await service.AdicionaLoja(lojaVw);

        if (adicionado)
        {
            return Created();
        }

        return BadRequest();
    }

    [HttpPatch]
    [Route("lojas/{id:int}")]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] LojasPatchViewModel lojaVw)
    {
        var atualizado = await service.AtualizarLoja(id, lojaVw);

        if (atualizado)
        {
            return NoContent();
        }

        return BadRequest();

    }

    [HttpDelete]
    [Route("lojas/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletado = await service.DeleteLoja(id);

        if (deletado)
        {
            return Ok();
        }

        return BadRequest();
    }
}

