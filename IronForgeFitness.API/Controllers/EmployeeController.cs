using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{

    // GET api/employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
    {
        return Ok();
    }

    // GET api/employees/{employeeId}
    [HttpGet("{employeeId}")]
    public async Task<ActionResult<Employee>> Get(Guid employeeId)
    {
        return Ok();
    }

    // POST api/employees
    [HttpPost]
    public async Task<ActionResult<Employee>> Create(Employee employee)
    {
        return Ok();
    }

    // PUT api/employees
    [HttpPut]
    public async Task<IActionResult> Update(Employee employee)
    {
        return Ok();
    }

    // DELETE api/employees/{employeeId}
    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> Delete(Guid employeeId)
    {
        return Ok();
    }
}
