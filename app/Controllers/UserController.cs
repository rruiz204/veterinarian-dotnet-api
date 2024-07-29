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
public class UserController(IUserService service, IJwtToken jwt) : ControllerBase
{
  private readonly IUserService _service = service;
  private readonly IJwtToken _jwt = jwt;

  [HttpPost("Register")]
  public async Task<IActionResult> CreateUser([FromForm] User user)
  {
    User response = await _service.CreateUser(user);
    string token = _jwt.Generate(response.Id);
    return Ok(new AuthenticationDTO(token));
  }

  [HttpPost("Login")]
  public async Task<IActionResult> LoginUser([FromForm] LoginDTO user)
  {
    User response = await _service.LoginUser(user);
    string token = _jwt.Generate(response.Id);
    return Ok(new AuthenticationDTO(token));
  }
}