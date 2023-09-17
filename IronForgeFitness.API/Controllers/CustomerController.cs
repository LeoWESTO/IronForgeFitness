using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly CustomerService _customerService;

    public CustomerController(
        IMapper mapper,
        CustomerService customerService)
    {
        _mapper = mapper;
        _customerService = customerService;
    }

    // GET api/customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomersList>>> GetAll(
        uint page = 1, 
        uint itemsPerPage = 10)
    {
        try
        {
            var customers = _mapper.Map<List<CustomerGet>>(await _customerService.GetCustomersAsync((int)page, (int)itemsPerPage));
            var res = new CustomersList(page, itemsPerPage, (uint)await _customerService.TotalCount(), customers);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/customers/{customerId}
    [HttpGet("{customerId}")]
    public async Task<ActionResult<CustomerGet>> Get(Guid customerId)
    {
        try
        {
            var customer = await _customerService.GetCustomerAsync(customerId);
            var customerDTO = _mapper.Map<CustomerGet>(customer);
            return Ok(customerDTO);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    // POST api/customers
    [HttpPost]
    public async Task<IActionResult> Create(CustomerPost customerDTO)
    {
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerService.AddCustomerAsync(customer);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    // PUT api/customers
    [HttpPut]
    public async Task<IActionResult> Update(CustomerPut customerDTO)
    {
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerService.UpdateCustomerAsync(customer);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    // DELETE api/customers/{customerId}
    [HttpDelete("{customerId}")]
    public async Task<IActionResult> Delete(Guid customerId)
    {
        try
        {
            await _customerService.DeleteCustomerAsync(customerId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    // GET api/customers/{customerId}/subscriptions
    [HttpGet("{customerId}/subscriptions")]
    public async Task<ActionResult<SubscriptionGet>> GetCustomerSubscriptions(Guid customerId)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }
}
