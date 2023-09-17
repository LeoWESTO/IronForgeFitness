using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/items")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ItemService _itemService;

    public ItemController(
        IMapper mapper,
        ItemService itemService)
    {
        _mapper = mapper;
        _itemService = itemService;
    }

    // GET api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemGet>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var items = _mapper.Map<List<ItemGet>>(await _itemService.GetItemsAsync((int)page, (int)itemsPerPage));
            var res = new ItemsList(page, itemsPerPage, (uint)await _itemService.TotalCount(), items);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/items/{itemId}
    [HttpGet("{itemId}")]
    public async Task<ActionResult<ItemGet>> Get(Guid itemId)
    {
        try
        {
            var item = await _itemService.GetItemAsync(itemId);
            var itemDTO = _mapper.Map<ItemGet>(item);
            return Ok(itemDTO);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    // POST api/items
    [HttpPost]
    public async Task<IActionResult> Create(ItemPost itemDTO)
    {
        try
        {
            var item = _mapper.Map<Item>(itemDTO);
            await _itemService.AddItemAsync(item);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/items
    [HttpPut]
    public async Task<IActionResult> Update(ItemPut itemDTO)
    {
        try
        {
            var item = _mapper.Map<Item>(itemDTO);
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
    public async Task<IActionResult> Delete(Guid itemId)
    {
        try
        {
            await _itemService.DeleteItemAsync(itemId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}
