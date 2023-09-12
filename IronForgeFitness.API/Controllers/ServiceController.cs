using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/services")]
[ApiController]
public class ServiceController : ControllerBase
{

    // GET api/services
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetAll()
    {
        return Ok();
    }

    // GET api/services/{serviceId}
    [HttpGet("{serviceId}")]
    public async Task<ActionResult<Service>> Get(Guid serviceId)
    {
        return Ok();
    }

    // POST api/services
    [HttpPost]
    public async Task<ActionResult<Service>> Create(Service service)
    {
        return Ok();
    }

    // PUT api/services
    [HttpPut]
    public async Task<IActionResult> Update(Service service)
    {
        return Ok();
    }

    // DELETE api/services/{serviceId}
    [HttpDelete("{serviceId}")]
    public async Task<IActionResult> Delete(Guid serviceId)
    {
        return Ok();
    }
}
