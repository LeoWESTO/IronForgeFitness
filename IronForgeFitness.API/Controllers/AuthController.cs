using Microsoft.AspNetCore.Mvc;

namespace IronForgeFitness.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{

    [Route("signIn")]
    [HttpPost]
    public IActionResult SignIn([FromBody] object request)
    {

        return Unauthorized();
    }

    [Route("logout")]
    [HttpPost]
    public IActionResult Logout([FromBody] object request)
    {

        return Unauthorized();
    }
}
