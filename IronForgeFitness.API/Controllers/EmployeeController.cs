using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly EmployeeService _employeeService;

    public EmployeeController(
        IMapper mapper,
        EmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    // GET api/employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeGet>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var employees = _mapper.Map<List<EmployeeGet>>(await _employeeService.GetEmployeesAsync((int)page, (int)itemsPerPage));
            var res = new EmployeesList(page, itemsPerPage, (uint)await _employeeService.TotalCount(), employees);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/employees/{employeeId}
    [HttpGet("{employeeId}")]
    public async Task<ActionResult<EmployeeGet>> Get(Guid employeeId)
    {
        try
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);
            var employeeDTO = _mapper.Map<EmployeeGet>(employee);
            return Ok(employeeDTO);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    // POST api/employees
    [HttpPost]
    public async Task<IActionResult> Create(EmployeePost employeeDTO)
    {
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _employeeService.AddEmployeeAsync(employee);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/employees
    [HttpPut]
    public async Task<IActionResult> Update(EmployeePut employeeDTO)
    {
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    // DELETE api/employees/{employeeId}
    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> Delete(Guid employeeId)
    {
        try
        {
            await _employeeService.DeleteEmployeeAsync(employeeId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}
