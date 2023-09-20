using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/transactions")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITransactionService _transactionService;

    public TransactionController(
        IMapper mapper,
        ITransactionService transactionService)
    {
        _mapper = mapper;
        _transactionService = transactionService;
    }

    // GET api/transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var transactionDTOs = _mapper.Map<List<TransactionResponse>>(await _transactionService.GetTransactionsAsync((int)page, (int)itemsPerPage));
            var res = new TransactionsList(page, itemsPerPage, (uint)await _transactionService.TotalCount(), transactionDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/transactions/{transactionId}
    [HttpGet("{transactionId}")]
    public async Task<ActionResult<TransactionResponse>> Get(Guid transactionId)
    {
        try
        {
            var transaction = await _transactionService.GetTransactionAsync(transactionId);
            var transactionDTO = _mapper.Map<TransactionResponse>(transaction);
            return Ok(transactionDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // PUT api/transactions/{transactionId}
    [HttpPut("{transactionId}")]
    public async Task<IActionResult> Update(Guid transactionId, TransactionRequest transactionDTO)
    {
        try
        {
            var transaction = _mapper.Map<Transaction>(transactionDTO);
            transaction.Id = transactionId;

            await _transactionService.UpdateTransactionAsync(transaction);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
