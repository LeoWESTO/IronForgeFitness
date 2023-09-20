using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/subscriptions")]
[ApiController]
public class SubscriptionController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionService _subsriptionService;

    public SubscriptionController(
        IMapper mapper,
        ISubscriptionService subsriptionService)
    {
        _mapper = mapper;
        _subsriptionService = subsriptionService;
    }

    // GET api/subscriptions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionsList>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var subscriptionDTOs = _mapper.Map<List<SubscriptionResponse>>(await _subsriptionService.GetSubscriptionsAsync((int)page, (int)itemsPerPage));
            var res = new SubscriptionsList(page, itemsPerPage, (uint)await _subsriptionService.TotalCount(), subscriptionDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/subscriptions/{subscriptionId}
    [HttpGet("{subscriptionId}")]
    public async Task<ActionResult<Subscription>> Get(Guid subscriptionId)
    {
        try
        {
            var subscription = await _subsriptionService.GetSubscriptionAsync(subscriptionId);
            var subscriptionDTO = _mapper.Map<SubscriptionResponse>(subscription);
            return Ok(subscriptionDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST api/subscriptions
    [HttpPost]
    public async Task<ActionResult<SubscriptionResponse>> Create(SubscriptionRequest subscriptionDTO)
    {
        try
        {
            var subscription = _mapper.Map<Subscription>(subscriptionDTO);
            await _subsriptionService.OpenSubscriptionAsync(subscription);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/subscriptions/{subscriptionId}
    [HttpPut("{subscriptionId}")]
    public async Task<IActionResult> Update(Guid subscriptionId, SubscriptionRequest subscriptionDTO)
    {
        try
        {
            var subscription = _mapper.Map<Subscription>(subscriptionDTO);
            subscription.Id = subscriptionId;

            await _subsriptionService.UpdateSubscriptionAsync(subscription);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/subscriptions/{subscriptionId}
    [HttpDelete("{subscriptionId}")]
    public async Task<IActionResult> Delete(Guid subscriptionId)
    {
        try
        {
            await _subsriptionService.CloseSubscriptionAsync(subscriptionId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
