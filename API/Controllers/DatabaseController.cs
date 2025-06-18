using API.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("Database")]
    public class DatabaseController(ApiDBContext context) : ControllerBase
{
    [HttpGet]
    [Route("Create")]
        public IActionResult Create()
        {
            context.Database.EnsureCreated();
        return Ok();
        }

    [HttpGet]
    [Route("Delete")]
    public IActionResult Delete()
    {
        context.Database.EnsureDeleted();
        return Ok();
    }


}

