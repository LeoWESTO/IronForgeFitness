using IronForgeFitness.API.DTOs;
using IronForgeFitness.API.Services;
using IronForgeFitness.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IronForgeFitness.API.Controllers;

[AllowAnonymous]
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly AuthService _authService;

    public AuthController(
        IAccountService accountService,
        AuthService authService)
    {
        _accountService = accountService;
        _authService = authService;
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] AuthCredentials credentials)
    {
        try
        {
            var account = await _accountService.GetByEmail(credentials.Email);

            if (account is null) return NotFound();
            if (account.PasswordHash != AuthService.HashPassword(credentials.Password)) return BadRequest();

            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Email, account.Email),
            new Claim(ClaimTypes.Role, account.Role),
            };
            var token = _authService.GenerateToken(claims);

            return Ok(new AuthToken(token));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
