using Microsoft.AspNetCore.Mvc;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service) : ControllerBase
{
  private readonly IUserService _service = service;

  [HttpPost("Register")]
  public async Task<IActionResult> CreateUser([FromForm] User user)
  {
    User response = await _service.CreateUser(user);
    return Ok(response);
  }
}