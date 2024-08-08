using Microsoft.AspNetCore.Mvc;
using Veterinarian_Dotnet_Api.App.DTO;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Filters;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Controllers;

[ApiController]
[Route("api/[controller]")]
[TypeFilter<ArgumentExceptionFilter>]
public class AuthController (
  IResetTokenService resetTokenService,
  IUserService userService,
  ITokens tokens
) : ControllerBase
{
  private readonly IUserService _userService = userService;
  private readonly IResetTokenService _resetTokenService = resetTokenService;
  private readonly ITokens _tokens = tokens;

  [HttpPost("Register")]
  public async Task<IActionResult> RegisterUser([FromForm] User user)
  {
    User registeredUser = await _userService.CreateUser(user);
    string jwt = _tokens.Generate(registeredUser.Id);
    return Ok(new AuthResponseDTO(jwt));
  }

  [HttpPost("Login")]
  public async Task<IActionResult> LoginUser([FromForm] LoginDTO dto)
  {
    User loggedUser = await _userService.LoginUser(dto);
    string jwt = _tokens.Generate(loggedUser.Id);
    return Ok(new AuthResponseDTO(jwt));
  }

  [HttpPost("ForgetPassword")]
  public async Task<IActionResult> ForgetPassword([FromForm] string email)
  {
    await _resetTokenService.SendEmail(email);
    return Ok();
  }

  [HttpPost("ResetPassword")]
  public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDTO dto)
  {
    await _resetTokenService.ResetPassword(dto);
    return Ok();
  }
}