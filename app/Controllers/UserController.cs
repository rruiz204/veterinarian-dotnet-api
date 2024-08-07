using Microsoft.AspNetCore.Mvc;
using Veterinarian_Dotnet_Api.App.Filters;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;
using Veterinarian_Dotnet_Api.App.DTO;

namespace Veterinarian_Dotnet_Api.App.Controllers;

[ApiController]
[TypeFilter<ArgumentExceptionFilter>]
[Route("api/[controller]")]
public class UserController(
  IUserService userService,
  IResetTokenService resetTokenService,
  IJwtToken jwt
) : ControllerBase
{
  private readonly IUserService _userService = userService;
  private readonly IResetTokenService _resetTokenService = resetTokenService;
  private readonly IJwtToken _jwt = jwt;

  [HttpPost("Register")]
  public async Task<IActionResult> CreateUser([FromForm] User user)
  {
    User response = await _userService.CreateUser(user);
    string token = _jwt.Generate(response.Id);
    return Ok(new AuthenticationDTO(token));
  }

  [HttpPost("Login")]
  public async Task<IActionResult> LoginUser([FromForm] LoginDTO user)
  {
    User response = await _userService.LoginUser(user);
    string token = _jwt.Generate(response.Id);
    return Ok(new AuthenticationDTO(token));
  }

  [HttpPost("Forget")]
  public async Task<IActionResult> ForgetPassword([FromForm] string email)
  {
    await _resetTokenService.SendEmail(email);
    return Ok(new { message = "forget endpoint" });
  }

  [HttpPost("Reset")]
  public async Task<IActionResult> ResetPassword([FromForm] string token, [FromForm] string password)
  {
    await _resetTokenService.ResetPassword(token, password);
    return Ok(new { message = "reset endpoint" });
  }
}