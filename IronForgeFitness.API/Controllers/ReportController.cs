using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/reports")]
[ApiController]
public class ReportController : ControllerBase
{

    // GET api/reports
    [HttpGet]
    public async Task<ActionResult<Report>> Get()
    {
        return Ok();
    }
}
