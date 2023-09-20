using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/items")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IItemService _itemService;

    public ItemController(
        IMapper mapper,
        IItemService itemService)
    {
        _mapper = mapper;
        _itemService = itemService;
    }

    // GET api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemResponse>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var itemDTOs = _mapper.Map<List<ItemResponse>>(await _itemService.GetItemsAsync((int)page, (int)itemsPerPage));
            var res = new ItemsList(page, itemsPerPage, (uint)await _itemService.TotalCount(), itemDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/items/{itemId}
    [HttpGet("{itemId}")]
    public async Task<ActionResult<ItemResponse>> Get(Guid itemId)
    {
        try
        {
            var item = await _itemService.GetItemAsync(itemId);
            var itemDTO = _mapper.Map<ItemResponse>(item);
            return Ok(itemDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST api/items
    [HttpPost]
    public async Task<IActionResult> Create(ItemRequest itemDTO)
    {
        try
        {
            var item = _mapper.Map<Item>(itemDTO);
            await _itemService.BuyItemAsync(item);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    // PUT api/items/{itemId}
    [HttpPut("{itemId}")]
    public async Task<IActionResult> Update(Guid itemId, ItemRequest itemDTO)
    {
        try
        {
            var item = _mapper.Map<Item>(itemDTO);
            item.Id = itemId;

            await _itemService.UpdateItemAsync(item);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/items/{itemId}
    [HttpDelete("{itemId}")]
    public async Task<IActionResult> Delete(Guid itemId, decimal price)
    {
        try
        {
            await _itemService.SellItemAsync(itemId, price);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
