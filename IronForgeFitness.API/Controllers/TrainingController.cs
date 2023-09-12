using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/trainings")]
[ApiController]
public class TrainingController : ControllerBase
{

    // GET api/trainings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Training>>> GetAll()
    {
        return Ok();
    }

    // GET api/trainings/{trainingId}
    [HttpGet("{trainingId}")]
    public async Task<ActionResult<Training>> Get(Guid trainingId)
    {
        return Ok();
    }

    // POST api/trainings
    [HttpPost]
    public async Task<ActionResult<Training>> Create(Training training)
    {
        return Ok();
    }

    // PUT api/trainings
    [HttpPut]
    public async Task<IActionResult> Update(Training training)
    {
        return Ok();
    }

    // DELETE api/trainings/{trainingId}
    [HttpDelete("{trainingId}")]
    public async Task<IActionResult> Delete(Guid trainingId)
    {
        return Ok();
    }
}
