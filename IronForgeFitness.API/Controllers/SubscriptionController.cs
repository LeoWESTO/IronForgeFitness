using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/subscriptions")]
[ApiController]
public class SubscriptionController : ControllerBase
{

    // GET api/subscriptions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subscription>>> GetAll()
    {
        return Ok();
    }

    // GET api/subscriptions/{subscriptionId}
    [HttpGet("{subscriptionId}")]
    public async Task<ActionResult<Subscription>> Get(Guid subscriptionId)
    {
        return Ok();
    }

    // POST api/subscriptions
    [HttpPost]
    public async Task<ActionResult<Subscription>> Create(Subscription subscription)
    {
        return Ok();
    }

    // PUT api/subscriptions
    [HttpPut]
    public async Task<IActionResult> Update(Subscription subscription)
    {
        return Ok();
    }

    // DELETE api/subscriptions/{subscriptionId}
    [HttpDelete("{subscriptionId}")]
    public async Task<IActionResult> Delete(Guid subscriptionId)
    {
        return Ok();
    }
}
