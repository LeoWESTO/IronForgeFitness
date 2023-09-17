using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/trainings")]
[ApiController]
public class TrainingController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITrainingService _trainingService;

    public TrainingController(
        IMapper mapper,
        ITrainingService trainingService)
    {
        _mapper = mapper;
        _trainingService = trainingService;
    }

    // GET api/trainings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingsList>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var trainingDTOs = _mapper.Map<List<TrainingResponse>>(await _trainingService.GetTrainingsAsync((int)page, (int)itemsPerPage));
            var res = new TrainingsList(page, itemsPerPage, (uint)await _trainingService.TotalCount(), trainingDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/trainings/{trainingId}
    [HttpGet("{trainingId}")]
    public async Task<ActionResult<TrainingResponse>> Get(Guid trainingId)
    {
        try
        {
            var training = await _trainingService.GetTrainingAsync(trainingId);
            var trainingDTO = _mapper.Map<TrainingResponse>(training);
            return Ok(trainingDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST api/trainings
    [HttpPost]
    public async Task<IActionResult> Create(TrainingRequest trainingDTO)
    {
        try
        {
            var training = _mapper.Map<Training>(trainingDTO);
            await _trainingService.ScheduleTrainingAsync(training);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/trainings/{trainingId}
    [HttpPut("{trainingId}")]
    public async Task<IActionResult> Update(Guid trainingId, TrainingRequest trainingDTO)
    {
        try
        {
            var training = _mapper.Map<Training>(trainingDTO);
            training.Id = trainingId;

            await _trainingService.UpdateTrainingAsync(training);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/trainings/{trainingId}
    [HttpDelete("{trainingId}")]
    public async Task<IActionResult> Delete(Guid trainingId)
    {
        try
        {
            await _trainingService.DeleteTrainingAsync(trainingId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
