using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;

    public AccountController(
        IMapper mapper,
        IAccountService accountService)
    {
        _mapper = mapper;
        _accountService = accountService;
    }

    // GET api/accounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountsList>>> GetAll(
        uint page = 1,
        uint itemsPerPage = 10)
    {
        try
        {
            var accountDTOs = _mapper.Map<List<AccountResponse>>(await _accountService.GetAccountsAsync((int)page, (int)itemsPerPage));
            var res = new AccountsList(page, itemsPerPage, (uint)await _accountService.TotalCount(), accountDTOs);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/accounts/{accountsId}
    [HttpGet("{accountsId}")]
    public async Task<ActionResult<AccountResponse>> Get(Guid accountId)
    {
        try
        {
            var account = await _accountService.GetAccountAsync(accountId);
            var accountDTO = _mapper.Map<AccountResponse>(account);
            return Ok(accountDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST api/accounts
    [HttpPost]
    public async Task<IActionResult> Create(AccountRequest accountDTO)
    {
        try
        {
            var account = _mapper.Map<Account>(accountDTO);
            await _accountService.SignUpAsync(account);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/accounts/{accountId}
    [HttpPut("{accountId}")]
    public async Task<IActionResult> Update(Guid accountId, AccountRequest accountDTO)
    {
        try
        {
            var account = _mapper.Map<Account>(accountDTO);
            account.Id = accountId;

            await _accountService.UpdateAccountAsync(account);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/accounts/{accountId}
    [HttpDelete("{accountId}")]
    public async Task<IActionResult> Delete(Guid accountId)
    {
        try
        {
            await _accountService.DeleteAccountAsync(accountId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
