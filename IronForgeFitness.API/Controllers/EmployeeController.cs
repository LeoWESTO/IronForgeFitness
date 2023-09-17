using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.API.Mapper;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(
        IMapper mapper,
        IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    // GET api/employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var employeeDTOs = _mapper.Map<List<EmployeeResponse>>(await _employeeService.GetEmployeesAsync((int)page, (int)itemsPerPage));
            var res = new EmployeesList(page, itemsPerPage, (uint)await _employeeService.TotalCount(), employeeDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/employees/{employeeId}
    [HttpGet("{employeeId}")]
    public async Task<ActionResult<EmployeeResponse>> Get(Guid employeeId)
    {
        try
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);
            var employeeDTO = _mapper.Map<EmployeeResponse>(employee);
            return Ok(employeeDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST api/employees
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeRequest employeeDTO)
    {
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);

            await _employeeService.HireEmployeeAsync(employee);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/employees/{employeeId}
    [HttpPut("{employeeId}")]
    public async Task<IActionResult> Update(Guid employeeId, EmployeeRequest employeeDTO)
    {
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            employee.Id = employeeId;

            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/employees/{employeeId}
    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> Delete(Guid employeeId)
    {
        try
        {
            await _employeeService.FireEmployeeAsync(employeeId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
