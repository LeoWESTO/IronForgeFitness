using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/items")]
[ApiController]
public class ItemController : ControllerBase
{

    // GET api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetAll()
    {
        return Ok();
    }

    // GET api/items/{itemId}
    [HttpGet("{itemId}")]
    public async Task<ActionResult<Item>> Get(Guid itemId)
    {
        return Ok();
    }

    // POST api/items
    [HttpPost]
    public async Task<ActionResult<Item>> Create(Item item)
    {
        return Ok();
    }

    // PUT api/items
    [HttpPut]
    public async Task<IActionResult> Update(Item item)
    {
        return Ok();
    }

    // DELETE api/items/{itemId}
    [HttpDelete("{itemId}")]
    public async Task<IActionResult> Delete(Guid itemId)
    {
        return Ok();
    }
}
