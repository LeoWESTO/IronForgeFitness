using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;

    public AuthController(
        IMapper mapper,
        IAccountService accountService)
    {
        _mapper = mapper;
        _accountService = accountService;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] AuthCredentials credentials)
    {

        return Unauthorized();
    }

    [Route("logout")]
    [HttpPost]
    public IActionResult Logout()
    {

        return Unauthorized();
    }
}
