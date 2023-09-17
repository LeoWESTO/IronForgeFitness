using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{

    // GET api/accounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountGet>>> GetAll()
    {
        return Ok();
    }

    // GET api/accounts/{accountsId}
    [HttpGet("{accountsId}")]
    public async Task<ActionResult<AccountGet>> Get(Guid accountId)
    {
        return Ok();
    }

    // POST api/accounts
    [HttpPost]
    public async Task<ActionResult<AccountGet>> Create(AccountPost account)
    {
        return Ok();
    }

    // PUT api/accounts
    [HttpPut]
    public async Task<IActionResult> Update(AccountPut account)
    {
        return Ok();
    }

    // DELETE api/accounts/{accountId}
    [HttpDelete("{accountId}")]
    public async Task<IActionResult> Delete(Guid accountId)
    {
        return Ok();
    }
}
