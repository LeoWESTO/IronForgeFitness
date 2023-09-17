using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/gyms")]
[ApiController]
public class GymController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IGymService _gymService;

    public GymController(
        IMapper mapper,
        IGymService gymService)
    {
        _mapper = mapper;
        _gymService = gymService;
    }

    // GET api/gyms
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingsList>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var gymDTOs = _mapper.Map<List<GymResponse>>(await _gymService.GetGymsAsync((int)page, (int)itemsPerPage));
            var res = new GymsList(page, itemsPerPage, (uint)await _gymService.TotalCount(), gymDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/gyms/{gymId}
    [HttpGet("{gymId}")]
    public async Task<ActionResult<GymResponse>> Get(Guid gymId)
    {
        try
        {
            var gym = await _gymService.GetGymAsync(gymId);
            var gymDTO = _mapper.Map<GymResponse>(gym);
            return Ok(gymDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST api/gyms
    [HttpPost]
    public async Task<IActionResult> Create(GymRequest gymDTO)
    {
        try
        {
            var gym = _mapper.Map<Gym>(gymDTO);
            await _gymService.OpenGymAsync(gym);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/gyms/{gymId}
    [HttpPut("{gymId}")]
    public async Task<IActionResult> Update(Guid gymId, GymRequest gymDTO)
    {
        try
        {
            var gym = _mapper.Map<Gym>(gymDTO);
            gym.Id = gymId;

            await _gymService.UpdateGymAsync(gym);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/gyms/{gymId}
    [HttpDelete("{gymId}")]
    public async Task<IActionResult> Delete(Guid gymId)
    {
        try
        {
            await _gymService.CloseGymAsync(gymId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
