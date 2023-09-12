using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{

    // GET api/customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
    {
        return Ok();
    }

    // GET api/customers/{customerId}
    [HttpGet("{customerId}")]
    public async Task<ActionResult<Customer>> Get(Guid customerId)
    {
        return Ok();
    }

    // POST api/customers
    [HttpPost]
    public async Task<ActionResult<Customer>> Create(Customer customer)
    {
        return Ok();
    }

    // PUT api/customers
    [HttpPut]
    public async Task<IActionResult> Update(Customer customer)
    {
        return Ok();
    }

    // DELETE api/customers/{customerId}
    [HttpDelete("{customerId}")]
    public async Task<IActionResult> Delete(Guid customerId)
    {
        return Ok();
    }
}
