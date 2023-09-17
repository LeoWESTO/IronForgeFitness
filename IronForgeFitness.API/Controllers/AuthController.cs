using IronForgeFitness.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{

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
