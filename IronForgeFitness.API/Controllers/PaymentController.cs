using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/payments")]
[ApiController]
public class PaymentController : ControllerBase
{

    // GET api/payments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetAll()
    {
        return Ok();
    }

    // GET api/payments/{paymentId}
    [HttpGet("{customerId}")]
    public async Task<ActionResult<Payment>> Get(Guid paymentId)
    {
        return Ok();
    }

    // POST api/payments
    [HttpPost]
    public async Task<ActionResult<Payment>> Create(Payment payment)
    {
        return Ok();
    }

    // PUT api/payments
    [HttpPut]
    public async Task<IActionResult> Update(Payment payment)
    {
        return Ok();
    }

    // DELETE api/payments/{paymentId}
    [HttpDelete("{paymentId}")]
    public async Task<IActionResult> Delete(Guid paymentId)
    {
        return Ok();
    }
}
