using Core.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserManager userManager) : ControllerBase
{
    
    [HttpPost]
    public IActionResult Login([FromBody] User user)
    {
        var response = userManager.Login(user);

        if (string.IsNullOrWhiteSpace(response))
        {
            return Unauthorized();
        }

        return Ok(response);
    }
}