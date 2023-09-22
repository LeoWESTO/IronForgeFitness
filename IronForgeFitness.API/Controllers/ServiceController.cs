using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/services")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceService _serviceService;

    public ServiceController(
        IMapper mapper,
        IServiceService serviceService)
    {
        _mapper = mapper;
        _serviceService = serviceService;
    }
    // GET api/services
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServicesList>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var serviceDTOs = _mapper.Map<List<ServiceResponse>>(await _serviceService.GetServicesAsync((int)page, (int)itemsPerPage));
            var res = new ServicesList(page, itemsPerPage, (uint)await _serviceService.TotalCount(), serviceDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/services/{serviceId}
    [HttpGet("{serviceId}")]
    public async Task<ActionResult<ServiceResponse>> Get(Guid serviceId)
    {
        try
        {
            var service = await _serviceService.GetServiceAsync(serviceId);
            var serviceDTO = _mapper.Map<ServiceResponse>(service);
            return Ok(serviceDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST api/services/
    [HttpPost]
    public async Task<ActionResult<Service>> Create(ServiceRequest serviceDTO)
    {
        try
        {
            var service = _mapper.Map<Service>(serviceDTO);
            await _serviceService.AddServiceAsync(service);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/services/serviceId
    [HttpPut("{serviceId}")]
    public async Task<IActionResult> Update(Guid serviceId, ServiceRequest serviceDTO)
    {
        try
        {
            var service = _mapper.Map<Service>(serviceDTO);
            service.Id = serviceId;

            await _serviceService.UpdateServiceAsync(service);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/services/{serviceId}
    [HttpDelete("{serviceId}")]
    public async Task<IActionResult> Delete(Guid serviceId)
    {
        try
        {
            await _serviceService.DeleteServiceAsync(serviceId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
